using KKKKPPP.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KKKKPPP.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            UserViewModel.userType = "None";
            return View();
        }
        public ViewResult Administrator()
        {
            UserViewModel.userType = "Admin";
            return View();
        }
        public ViewResult User()
        {
            UserViewModel.userType = "User";
            return View();
        }
    }
}
