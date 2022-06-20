using KKKKPPP.Data;
using KKKKPPP.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KKKKPPP.Controllers
{
    public class HomeController : DefaultController
    {
        private readonly AppDBContext db;

        public HomeController(AppDBContext appDB )
        {
            db = appDB;
        }

        public IActionResult Index()
        {
            setTheme();
            return RedirectToAction("UserAccount", "Home");
        }
        [Authorize]
        public ViewResult Administrator()
        {
            return View();
        }
        public ViewResult UserAccount()
        {
            setTheme();
            GalleryViewModel obj = new GalleryViewModel
            {
                allExpos = db.Экспозиция,
                allExcurs = db.Экскурсия
            };
            return View(obj);
        }
    }
}
