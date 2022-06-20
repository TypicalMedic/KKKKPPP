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
using Microsoft.AspNetCore.Authorization;
using KKKKPPP.Data.Models.ClientSide;
using System;
using System.Security.Cryptography;

namespace KKKKPPP.Controllers
{
    public class AccountController : DefaultController
    {
        private readonly AppDBContext db;
        private readonly IЭкспозиция _Expos;
        public AccountController(AppDBContext context, IЭкспозиция iEx)
        {
            db = context;
            _Expos = iEx;
        }
        [Authorize]
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
        [Authorize]
        public ViewResult ChangeSuccessful()
        {
            return View();
        }
        [Authorize]
        public ViewResult ChangeName(string ErrorMessage)
        {
            AccountViewModel obj = new AccountViewModel
            {
                ErrorMessage = ErrorMessage
            };
            return View(obj);
        }

        [Authorize]
        [HttpPost]
        public ActionResult ChangeName(string name, string password)
        {
            if (VerifyHashedPassword(UserViewModel.userInfo.Password, password))
            {
                UserViewModel.userInfo.Name = name;
                db.Entry(UserViewModel.userInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("UserAccount", "Account", new { mes = "Имя успешно изменено!"}) ;
            }
            return Redirect("ChangeName?ErrorMessage=Неверный пароль!");
        }
        [Authorize]
        public ViewResult ChangeEmail(string ErrorMessage)
        {
            AccountViewModel obj = new AccountViewModel
            {
                ErrorMessage = ErrorMessage
            };
            return View(obj);
        }

        [Authorize]
        [HttpPost]
        public ActionResult ChangeEmail(string email, string password)
        {
            if (VerifyHashedPassword(UserViewModel.userInfo.Password, password))
            {
                if (!db.User.Any(u => u.Email == email))
                {
                    UserViewModel.userInfo.Email = email;
                    db.Entry(UserViewModel.userInfo).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("UserAccount", "Account", new { mes = "Почта успешно изменена!" });
                }
                return Redirect("ChangeEmail?ErrorMessage=Аккаунт с данной почтой уже существует!");
            }
            return Redirect("ChangeEmail?ErrorMessage=Неверный пароль!");
        }
        [Authorize]
        public ViewResult ChangePassword(string ErrorMessage)
        {
            AccountViewModel obj = new AccountViewModel
            {
                ErrorMessage = ErrorMessage
            };
            return View(obj);
        }

        [Authorize]
        [HttpPost]
        public ActionResult ChangePassword(string newpassword, string confirmpassword, string password)
        {
            if (VerifyHashedPassword(UserViewModel.userInfo.Password, password))
            {
                if (newpassword == confirmpassword)
                {
                    UserViewModel.userInfo.Password = HashPassword(newpassword);
                    db.Entry(UserViewModel.userInfo).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("UserAccount", "Account", new { mes = "Пароль успешно изменен!" });
                }
                return Redirect("ChangePassword?ErrorMessage=Новый пароль повторен неверно!");
            }
            return Redirect("ChangePassword?ErrorMessage=Неверный пароль!");
        }
        [Authorize]
        public ViewResult UserAccount(string mes)
        {
            ViewBag.mes = mes;
            AccountViewModel obj = new AccountViewModel
            {
                allExpos = _Expos.Expos,
                allExcurs = db.Экскурсия
            };
            return View(obj);
        }
        [Authorize]
        public ViewResult Administrator()
        {
            return View();
        }
        public IActionResult Login()
        {
            setTheme();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await db.User.FirstOrDefaultAsync(u => u.Email == model.Email);
                if (user != null)
                {
                    bool checkPassword = VerifyHashedPassword(user.Password, model.Password);
                    if (checkPassword)
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
                    string hashedPassword = HashPassword(model.Password);
                    db.User.Add(new User { Name = model.Name, Email = model.Email, Password = hashedPassword, IsAdministrator = false, RegistrationDate = DateTime.Now });
                    await db.SaveChangesAsync();

                    await Authenticate(model.Email);

                    return RedirectToAction("Login", "Account");
                }
                ModelState.AddModelError("", "Пользователь с данной почтой уже зарегистрирован");
                return View(model);
            }
            ModelState.AddModelError("", "Пароль повторен неверно!");
            return View(model);
        }
        public static string HashPassword(string password)
        {
            byte[] salt;
            byte[] buffer2;
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }
            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, 0x10, 0x3e8))
            {
                salt = bytes.Salt;
                buffer2 = bytes.GetBytes(0x20);
            }
            byte[] dst = new byte[0x31];
            Buffer.BlockCopy(salt, 0, dst, 1, 0x10);
            Buffer.BlockCopy(buffer2, 0, dst, 0x11, 0x20);
            return Convert.ToBase64String(dst);
        }
        public static bool VerifyHashedPassword(string hashedPassword, string password)
        {
            byte[] buffer4;
            if (hashedPassword == null)
            {
                return false;
            }
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }
            byte[] src = Convert.FromBase64String(hashedPassword);
            if ((src.Length != 0x31) || (src[0] != 0))
            {
                return false;
            }
            byte[] dst = new byte[0x10];
            Buffer.BlockCopy(src, 1, dst, 0, 0x10);
            byte[] buffer3 = new byte[0x20];
            Buffer.BlockCopy(src, 0x11, buffer3, 0, 0x20);
            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, dst, 0x3e8))
            {
                buffer4 = bytes.GetBytes(0x20);
            }
            return ByteArraysEqual(buffer3, buffer4);
        }
        public static bool ByteArraysEqual(byte[] b1, byte[] b2)
        {
            if (b1 == b2) return true;
            if (b1 == null || b2 == null) return false;
            if (b1.Length != b2.Length) return false;
            for (int i = 0; i < b1.Length; i++)
            {
                if (b1[i] != b2[i]) return false;
            }
            return true;
        }

        //private async Task Authenticate(string userName)
        //{
        //    var claims = new List<Claim>
        //    {
        //        new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
        //    };
        //    ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
        //    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        //}

        public async Task<IActionResult> Logout()
        {
            UserViewModel.userType = "None";
            UserViewModel.userInfo = null;

            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("UserAccount", "Home");
        }
    }
}
