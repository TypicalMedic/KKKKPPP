using KKKKPPP.Data;
using KKKKPPP.Data.Interfaces;
using KKKKPPP.Data.Models;
using KKKKPPP.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KKKKPPP.Controllers
{
    public class DBViewController : Controller
    {
        private readonly IАвтор _Authors;
        private readonly IТехника _Techs;
        private readonly IСостояние _Conds;
        private readonly IСтатусКартины _StatsP;
        private readonly IСтатусЭкспозиции _StatsE;
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

        public DBViewController(AppDBContext appDB, IАвтор iA, IТехника iTq, IСостояние iCnd,
            IСтатусКартины iStp, IСтатусЭкспозиции iSte, IСтрана iCt, IЖанр iJ, IСтиль iSt, IСущности iSu, IКартина iPc,
            IРеставрация iR, IСвязь_Материал_Картина iMP, IСвязь_Рест_Вид iRT, IМатериал iM, IВид_реставрации iRtp,
            IМесто iPl, IЗал iRm, IЭкспозиция iEx, IЭкспонат iSh)
        {
            _Authors = iA;
            _Techs = iTq;
            _StatsP = iStp;
            _StatsE = iSte;
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
        public ViewResult DBView()
        {
            ViewBag.Title = "View Elements";
            DBViewViewModel obj = new DBViewViewModel
            {
                allАвтор = _Authors.Authors,
                allТехника = _Techs.Techniques,
                allСостояние_картины = _Conds.Conditions,
                allСтатус_картины = _StatsP.Statuses,
                ////allСтатус_экспозиции = _StatsE.EStatuses,
                allСтрана = _Countries.Countries,
                allЖанр = _Janres.Jenres,
                allСтиль = _Styles.Styles,
                allEntities = _Entities.Entities,
                allКартина = _Pictures.Pictures,
                allМатериал = _Materials.Materials,
                allСвязь_Материал_Картина = _Pic_Materials.Pic_Material,
                allРеставрация = _Restorations.Restorations,
                allСвязь_Рест_Вид = _Rest_Types.Rest_Types,
                allВид_реставрации = _RestorationTypes.Restoration_types,
                allЭкспозиция = _Expos.Expos,
                allМесто = _Places.Places,
                allЗал = _Rooms.Rooms,
                allЭкспонат = _Showp.Showpieces
            };
            return View(obj);
        }     
        public ViewResult Result(string type)
        {
            ViewBag.Title = "View Elements";
            DBViewViewModel obj = new DBViewViewModel
            {
                allАвтор = _Authors.Authors,
                allТехника = _Techs.Techniques,
                allСостояние_картины = _Conds.Conditions,
                allСтатус_картины = _StatsP.Statuses,
                //allСтатус_экспозиции = _StatsE.EStatuses,
                allСтрана = _Countries.Countries,
                allЖанр = _Janres.Jenres,
                allСтиль = _Styles.Styles,
                allEntities = _Entities.Entities,
                allEntityTypes = _Entities.EntityTypes,
                allКартина = _Pictures.Pictures,
                allМатериал = _Materials.Materials,
                allСвязь_Материал_Картина = _Pic_Materials.Pic_Material,
                allРеставрация = _Restorations.Restorations,
                allСвязь_Рест_Вид = _Rest_Types.Rest_Types,
                allВид_реставрации = _RestorationTypes.Restoration_types,
                allЭкспозиция = _Expos.Expos,
                allМесто = _Places.Places,
                allЗал = _Rooms.Rooms,
                allЭкспонат = _Showp.Showpieces,
                selType = type
            };
            return View(obj);
        }     
    }
}
