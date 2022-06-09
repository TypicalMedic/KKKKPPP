using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using KKKKPPP.Data;
using KKKKPPP.ViewModels;
using KKKKPPP.Data.Models;
using Microsoft.AspNetCore.Http;
using System.Linq;
using KKKKPPP.Data.Interfaces;

namespace KKKKPPP.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDBContext db;
        private readonly IЭкспозиция _Expos;
        public AccountController(AppDBContext context, IЭкспозиция iEx)
        {
            db = context;
            _Expos = iEx;
        }
        public IActionResult DeleteExcur(int excId)
        {
            string path = "Assets/Excursions/" + db.Экскурсия.FirstOrDefault(e => e.id == excId).Содержание;
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
            db.Экскурсия.Remove(db.Экскурсия.FirstOrDefault(e => e.id == excId));
            db.SaveChanges();
            return Redirect("UserAccount");
        }
        public ViewResult ChangeSuccessful()
        {
            return View();
        }
        public ViewResult ChangeName(string ErrorMessage)
        {
            AccountViewModel obj = new AccountViewModel
            {
                ErrorMessage = ErrorMessage
            };
            return View(obj);
        }

        [HttpPost]
        public RedirectResult ChangeName(string name, string password)
        {
            if (UserViewModel.userInfo.Password == password)
            {
                UserViewModel.userInfo.Name = name;
                db.Entry(UserViewModel.userInfo).State = EntityState.Modified;
                db.SaveChanges();
                return Redirect("ChangeSuccessful?type=name");
            }
            return Redirect("ChangeName?ErrorMessage=Неверный пароль!");
        }
        public ViewResult ChangeEmail(string ErrorMessage)
        {
            AccountViewModel obj = new AccountViewModel
            {
                ErrorMessage = ErrorMessage
            };
            return View(obj);
        }

        [HttpPost]
        public RedirectResult ChangeEmail(string email, string password)
        {
            if (UserViewModel.userInfo.Password == password)
            {
                if (!db.User.Any(u => u.Email == email))
                {
                    UserViewModel.userInfo.Email = email;
                    db.Entry(UserViewModel.userInfo).State = EntityState.Modified;
                    db.SaveChanges();
                    return Redirect("ChangeSuccessful?type=email");
                }
                return Redirect("ChangeEmail?ErrorMessage=Аккаунт с данной почтой уже существует!");
            }
            return Redirect("ChangeEmail?ErrorMessage=Неверный пароль!");
        }
        public ViewResult ChangePassword(string ErrorMessage)
        {
            AccountViewModel obj = new AccountViewModel
            {
                ErrorMessage = ErrorMessage
            };
            return View(obj);
        }

        [HttpPost]
        public RedirectResult ChangePassword(string newpassword, string confirmpassword, string password)
        {
            if (UserViewModel.userInfo.Password == password)
            {
                if (newpassword == confirmpassword)
                {
                    UserViewModel.userInfo.Password = newpassword;
                    db.Entry(UserViewModel.userInfo).State = EntityState.Modified;
                    db.SaveChanges();
                    return Redirect("ChangeSuccessful?type=password");
                }
                return Redirect("ChangeEmail?ErrorMessage=Новый пароль повторен неверно!");
            }
            return Redirect("ChangeEmail?ErrorMessage=Неверный пароль!");
        }
        public ViewResult UserAccount()
        {
            AccountViewModel obj = new AccountViewModel
            {
                allExpos = _Expos.Expos,
                allExcurs = db.Экскурсия
            };
            return View(obj);
        }
        public ViewResult Administrator()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await db.User.FirstOrDefaultAsync(u => u.Email == model.Email && u.Password == model.Password);
                if (user != null)
                {
                    await Authenticate(model.Email); // аутентификация
                    if (user.IsAdministrator)
                    {
                        UserViewModel.userType = "Admin";
                        user.LikedExpos = db.LikeExpo.Where(e => e.UserId == user.Id).Select(s => s.ExpoId).ToList();
                        user.LikedExcurs = db.LikeExcur.Where(e => e.UserId == user.Id).Select(s => s.ExcurId).ToList();
                        UserViewModel.userInfo = user;
                        return RedirectToAction("Administrator", "Home");
                    }
                    else
                    {
                        UserViewModel.userType = "User";
                        user.LikedExpos = db.LikeExpo.Where(e => e.UserId == user.Id).Select(s => s.ExpoId).ToList();
                        user.LikedExcurs = db.LikeExcur.Where(e => e.UserId == user.Id).Select(s => s.ExcurId).ToList();
                        UserViewModel.userInfo = user;
                        return RedirectToAction("UserAccount", "Account");
                    }
                }
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await db.User.FirstOrDefaultAsync(u => u.Email == model.Email);
                if (user == null)
                {
                    // добавляем пользователя в бд
                    db.User.Add(new User { Name = model.Name, Email = model.Email, Password = model.Password, IsAdministrator = false, RegistrationDate = System.DateTime.Now });
                    await db.SaveChangesAsync();

                    await Authenticate(model.Email); // аутентификация

                    return RedirectToAction("Login", "Account");
                }
                else
                    ModelState.AddModelError("", "Пользователь с данной почтой уже зарегистрирован");
            }
            return View(model);
        }

        private async Task Authenticate(string userName)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public async Task<IActionResult> Logout()
        {
            UserViewModel.userType = "None";
            UserViewModel.userInfo = null;

            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("UserAccount", "Home");
        }
    }
}
