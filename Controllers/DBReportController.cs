using KKKKPPP.Data.Interfaces;
using KKKKPPP.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KKKKPPP.Controllers
{
    public class DBReportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public ViewResult DBReport()
        {
            ViewBag.Title = "Add Element";
            DBReportViewModel obj = new DBReportViewModel();
            return View(obj);
        }
    }
}
