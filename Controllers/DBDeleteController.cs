using KKKKPPP.Data;
using KKKKPPP.Data.Interfaces;
using KKKKPPP.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KKKKPPP.Controllers
{
    public class DBDeleteController : Controller
    {
        private readonly IАвтор _Authors;
        private readonly IТехника _Techs;
        private readonly IСостояние _Conds;
        private readonly IСтатусКартины _StatsP;
        private readonly IСтрана _Countries;
        private readonly IЖанр _Janres;
        private readonly IСтиль _Styles;
        private readonly IСущности _Entities;
        private readonly IКартина _Pictures;
        private readonly IМатериал _Materials;
        private readonly IРеставрация _Restorations;
        private readonly IСвязь_Материал_Картина _Pic_Materials;
        private readonly IСвязь_Рест_Вид _Rest_Types;
        private readonly IВид_реставрации _RestorationTypes;
        private readonly IЭкспонат _Showp;
        private readonly IЭкспозиция _Expos;
        private readonly IЗал _Rooms;
        private readonly IМесто _Places;
        private readonly AppDBContext db;
        private bool sp = false;
        private static int[] idP = new int[] { -1 };

        public DBDeleteController(AppDBContext appDB, IАвтор iA, IТехника iTq, IСостояние iCnd, 
            IСтатусКартины iStp, IСтрана iCt, IЖанр iJ, IСтиль iSt, IСущности iSu, IКартина iPc,
            IРеставрация iR, IСвязь_Материал_Картина iMP, IСвязь_Рест_Вид iRT, IМатериал iM, IВид_реставрации iRtp,
            IМесто iPl, IЗал iRm, IЭкспозиция iEx, IЭкспонат iSh)
        {
            _Authors = iA;
            _Techs = iTq;
            _StatsP = iStp;
            _Conds = iCnd;
            _Countries = iCt;
            _Janres = iJ;
            _Styles = iSt;
            _Entities = iSu;
            _Pictures = iPc;
            _Materials = iM;
            _Restorations = iR;
            _Rest_Types = iRT;
            _Pic_Materials = iMP;
            _RestorationTypes = iRtp;
            _Showp = iSh;
            _Expos = iEx;
            _Rooms = iRm;
            _Places = iPl;
            db = appDB;

        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ViewResult Картина(int[] value, bool clear)
        {
            if (clear)
            {
                sp = false;
                idP = new int[] {-1};
            }
            else
            {
                sp = true;
                idP = value;
            }
            return Картина();
        }
        public ViewResult DBDelete()
        {
            ViewBag.Title = "Delete Element";
            DBDeleteViewModel obj = new DBDeleteViewModel
            {
                allEntities = _Entities.Entities
            };
            return View(obj);
        }
        public ViewResult DeleteSuccessful()
        {
            ViewBag.Title = "Delete Successful"; 
            return View();
        }
        [HttpPost]
        public RedirectResult Delete()
        {
            try
            {
                foreach(var x in db.Картина.Where(p => idP.Contains(p.Инвентарный_номер)))
                {
                    db.Картина.Remove(x);
                }
                db.SaveChanges();
                return Redirect("/DBDelete/DeleteSuccessful");
            }
            catch
            {
                return Redirect("/DBDelete/DeleteUnsuccessful");
            }
        }
        public ViewResult Картина()
        {
            ViewBag.Title = "Delete Painting";
            DBDeleteViewModel obj = new DBDeleteViewModel
            {
                allAuthors = _Authors.Authors,
                allTechniques = _Techs.Techniques,
                allCondit = _Conds.Conditions,
                allStatus = _StatsP.Statuses,
                allCountries = _Countries.Countries,
                allJanres = _Janres.Jenres,
                allStyles = _Styles.Styles,
                allEntities = _Entities.Entities,
                allPictures = _Pictures.Pictures,
                allMaterials = _Materials.Materials,
                allPic_Materials = _Pic_Materials.Pic_Material,
                allRestorations = _Restorations.Restorations,
                allRest_Types = _Rest_Types.Rest_Types,
                allRestorationTypes = _RestorationTypes.Restoration_types,
                allExpos = _Expos.Expos,
                allPlaces = _Places.Places,
                allRooms = _Rooms.Rooms,
                allShowpieces = _Showp.Showpieces,
                isPicSelected = sp,
                idPic = idP
            };
            return View(obj);
        }
    }
}
