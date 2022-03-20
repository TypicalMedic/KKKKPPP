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
                allСтатус_экспозиции = _StatsE.EStatuses,
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
                allСтатус_экспозиции = _StatsE.EStatuses,
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

        public ViewResult Картина()
        {
            ViewBag.Title = "Add Painting";
            DBViewViewModel obj = new DBViewViewModel
            {
                allАвтор = _Authors.Authors,
                allТехника = _Techs.Techniques,
                allСостояние_картины = _Conds.Conditions,
                allСтатус_картины = _StatsP.Statuses,
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
        public ViewResult Автор()
        {
            ViewBag.Title = "Add Author";
            DBViewViewModel obj = new DBViewViewModel
            {
                allАвтор = _Authors.Authors,
                allТехника = _Techs.Techniques,
                allСостояние_картины = _Conds.Conditions,
                allСтатус_картины = _StatsP.Statuses,
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
        public ViewResult Вид_реставрации()
        {
            ViewBag.Title = "Add Restoration Type";
            DBViewViewModel obj = new DBViewViewModel
            {
                allАвтор = _Authors.Authors,
                allТехника = _Techs.Techniques,
                allСостояние_картины = _Conds.Conditions,
                allСтатус_картины = _StatsP.Statuses,
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
        public ViewResult Жанр()
        {
            ViewBag.Title = "Add Jenre";
            DBViewViewModel obj = new DBViewViewModel
            {
                allАвтор = _Authors.Authors,
                allТехника = _Techs.Techniques,
                allСостояние_картины = _Conds.Conditions,
                allСтатус_картины = _StatsP.Statuses,
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
        public ViewResult Зал()
        {
            ViewBag.Title = "Add Room";
            DBViewViewModel obj = new DBViewViewModel
            {
                allАвтор = _Authors.Authors,
                allТехника = _Techs.Techniques,
                allСостояние_картины = _Conds.Conditions,
                allСтатус_картины = _StatsP.Statuses,
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
        public ViewResult Материал()
        {
            ViewBag.Title = "Add Material";
            DBViewViewModel obj = new DBViewViewModel
            {
                allАвтор = _Authors.Authors,
                allТехника = _Techs.Techniques,
                allСостояние_картины = _Conds.Conditions,
                allСтатус_картины = _StatsP.Statuses,
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
        public ViewResult Место()
        {
            ViewBag.Title = "Add Place";
            DBViewViewModel obj = new DBViewViewModel
            {
                allАвтор = _Authors.Authors,
                allТехника = _Techs.Techniques,
                allСостояние_картины = _Conds.Conditions,
                allСтатус_картины = _StatsP.Statuses,
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
        public ViewResult Реставрация()
        {
            ViewBag.Title = "Add Restoration";
            DBViewViewModel obj = new DBViewViewModel
            {
                allАвтор = _Authors.Authors,
                allТехника = _Techs.Techniques,
                allСостояние_картины = _Conds.Conditions,
                allСтатус_картины = _StatsP.Statuses,
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
        public ViewResult Состояние_картины()
        {
            ViewBag.Title = "Add Picture conditiob";
            DBViewViewModel obj = new DBViewViewModel
            {
                allАвтор = _Authors.Authors,
                allТехника = _Techs.Techniques,
                allСостояние_картины = _Conds.Conditions,
                allСтатус_картины = _StatsP.Statuses,
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
        public ViewResult Статус_картины()
        {
            ViewBag.Title = "Add Peinting statue";
            DBViewViewModel obj = new DBViewViewModel
            {
                allАвтор = _Authors.Authors,
                allТехника = _Techs.Techniques,
                allСостояние_картины = _Conds.Conditions,
                allСтатус_картины = _StatsP.Statuses,
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
        public ViewResult Статус_экспозиции()
        {
            ViewBag.Title = "Add Exposition status";
            DBViewViewModel obj = new DBViewViewModel
            {
                allАвтор = _Authors.Authors,
                allТехника = _Techs.Techniques,
                allСостояние_картины = _Conds.Conditions,
                allСтатус_картины = _StatsP.Statuses,
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
        public ViewResult Стиль()
        {
            ViewBag.Title = "Add Style";
            DBViewViewModel obj = new DBViewViewModel
            {
                allАвтор = _Authors.Authors,
                allТехника = _Techs.Techniques,
                allСостояние_картины = _Conds.Conditions,
                allСтатус_картины = _StatsP.Statuses,
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
        public ViewResult Страна()
        {
            ViewBag.Title = "Add Country";
            DBViewViewModel obj = new DBViewViewModel
            {
                allАвтор = _Authors.Authors,
                allТехника = _Techs.Techniques,
                allСостояние_картины = _Conds.Conditions,
                allСтатус_картины = _StatsP.Statuses,
                allСтатус_экспозиции = _StatsE.EStatuses,
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
        public ViewResult Техника()
        {
            ViewBag.Title = "Add Technique";
            DBViewViewModel obj = new DBViewViewModel
            {
                allАвтор = _Authors.Authors,
                allТехника = _Techs.Techniques,
                allСостояние_картины = _Conds.Conditions,
                allСтатус_картины = _StatsP.Statuses,
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
        public ViewResult Экспозиция()
        {
            ViewBag.Title = "Add Exposition";
            DBViewViewModel obj = new DBViewViewModel
            {
                allАвтор = _Authors.Authors,
                allТехника = _Techs.Techniques,
                allСостояние_картины = _Conds.Conditions,
                allСтатус_картины = _StatsP.Statuses,
                allСтатус_экспозиции = _StatsE.EStatuses,
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
        public ViewResult Экспонат()
        {
            ViewBag.Title = "Add Showpiece";
            DBViewViewModel obj = new DBViewViewModel
            {
                allАвтор = _Authors.Authors,
                allТехника = _Techs.Techniques,
                allСостояние_картины = _Conds.Conditions,
                allСтатус_картины = _StatsP.Statuses,
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
        public ViewResult AddSuccessful()
        {
            ViewBag.Title = "Add Successful"; DBViewViewModel obj = new DBViewViewModel
            {
                allАвтор = _Authors.Authors,
                allТехника = _Techs.Techniques,
                allСостояние_картины = _Conds.Conditions,
                allСтатус_картины = _StatsP.Statuses,
                allСтрана = _Countries.Countries,
                allЖанр = _Janres.Jenres,
                allСтиль = _Styles.Styles,
                allEntities = _Entities.Entities
            };
            return View(obj);
        }

        [HttpPost]
        public RedirectResult Картина(Картина pic, string Высота, string Ширина, int[] materials)
        {
            //pic doesnt recognize float values
            //because of ,!
            try
            {
                pic.Высота = float.Parse(Высота.Replace('.', ','));
                pic.Ширина = float.Parse(Ширина.Replace('.', ','));
                db.Картина.Add(pic);
                db.SaveChanges();
                foreach (var x in materials)
                {
                    Связь_Материал_Картина newC = new Связь_Материал_Картина { Материал = x, Картина = db.Картина.OrderBy(p => p.Инвентарный_номер).LastOrDefault().Инвентарный_номер };
                    db.Связь_Материал_Картина.Add(newC);
                }
                db.SaveChanges();
                return Redirect("/DBAdd/AddSuccessful");
            }
            catch
            {
                return Redirect("/DBAdd/AddUnsuccessful");
            }
        }
        [HttpPost]
        public RedirectResult Автор(Автор ath)
        {
            db.Автор.Add(ath);
            db.SaveChanges();
            return Redirect("/DBAdd/AddSuccessful");
        }
        [HttpPost]
        public RedirectResult Вид_реставрации(Вид_реставрации rt)
        {
            db.Вид_реставрации.Add(rt);
            db.SaveChanges();
            return Redirect("/DBAdd/AddSuccessful");
        }
        [HttpPost]
        public RedirectResult Жанр(Жанр j)
        {
            db.Жанр.Add(j);
            db.SaveChanges();
            return Redirect("/DBAdd/AddSuccessful");
        }
        [HttpPost]
        public RedirectResult Зал(Зал r)
        {            
            db.Зал.Add(r);
            db.SaveChanges();
            return Redirect("/DBAdd/AddSuccessful");
        }
        [HttpPost]
        public RedirectResult Материал(Материал m)
        {
            db.Материал.Add(m);
            db.SaveChanges();
            return Redirect("/DBAdd/AddSuccessful");
        }
        [HttpPost]
        public RedirectResult Место(Место p)
        {
            db.Место.Add(p);
            db.SaveChanges();
            return Redirect("/DBAdd/AddSuccessful");
        }
        [HttpPost]
        public RedirectResult Реставрация(Реставрация rest, int[] rTypes)
        {
            db.Реставрация.Add(rest);
            db.SaveChanges(); 
            foreach (var x in rTypes)
            {
                Связь_Рест_Вид newC = new Связь_Рест_Вид { Вид_реставрации = x, Код_реставрации = db.Реставрация.OrderBy(p => p.Код_реставрации).LastOrDefault().Код_реставрации };
                db.Связь_Рест_Вид.Add(newC);
            }
            db.SaveChanges();
            return Redirect("/DBAdd/AddSuccessful");
        }
        [HttpPost]
        public RedirectResult Состояние_картины(Состояние_картины pc)
        {
            db.Состояние_картины.Add(pc);
            db.SaveChanges();

            return Redirect("/DBAdd/AddSuccessful");
        }
        [HttpPost]
        public RedirectResult Статус_картины(Статус_картины ps)
        {
            db.Статус_картины.Add(ps);
            db.SaveChanges();

            return Redirect("/DBAdd/AddSuccessful");
        }
        [HttpPost]
        public RedirectResult Статус_экспозиции(Статус_экспозиции es)
        {
            db.Статус_экспозиции.Add(es);
            db.SaveChanges();

            return Redirect("/DBAdd/AddSuccessful");
        }
        [HttpPost]
        public RedirectResult Стиль(Стиль s)
        {
            db.Стиль.Add(s);
            db.SaveChanges();

            return Redirect("/DBAdd/AddSuccessful");
        }
        [HttpPost]
        public RedirectResult Страна(Страна c)
        {
            c.НазваниеСтраны = AppDBContext.countries.FirstOrDefault(cc => int.Parse(cc.NumericCode) == c.Код_страны).Name;
            db.Страна.Add(c);
            db.SaveChanges();

            return Redirect("/DBAdd/AddSuccessful");
        }
        [HttpPost]
        public RedirectResult Техника(Техника t)
        {
            db.Техника.Add(t);
            db.SaveChanges();
            return Redirect("/DBAdd/AddSuccessful");
        }
        [HttpPost]
        public RedirectResult Экспозиция(Экспозиция e)
        {
            db.Экспозиция.Add(e);
            db.SaveChanges();

            return Redirect("/DBAdd/AddSuccessful");
        }
        [HttpPost]
        public RedirectResult Экспонат(Экспонат sh)
        {
            db.Экспонат.Add(sh);
            db.SaveChanges();

            return Redirect("/DBAdd/AddSuccessful");
        }
    }
}
