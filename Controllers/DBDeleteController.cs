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
        private static bool sp = false;
        private static string[] idP = new string[] { "-1" };

        public DBDeleteController(AppDBContext appDB, IАвтор iA, IТехника iTq, IСостояние iCnd,
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
            if (!sp)
            {
                idP = new string[] { "-1" };
            }
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ViewResult Картина(string[] value, bool clear)
        {
            if (clear)
            {
                sp = false;
                idP = new string[] { "-1" };
            }
            else
            {
                sp = true;
                idP = value;
            }
            return Картина();
        }
        [HttpPost]
        public ViewResult Автор(string[] value, bool clear)
        {
            if (clear)
            {
                sp = false;
                idP = new string[] { "-1" };
            }
            else
            {
                sp = true;
                idP = value;
            }
            return Автор();
        }
        [HttpPost]
        public ViewResult Вид_реставрации(string[] value, bool clear)
        {
            if (clear)
            {
                sp = false;
                idP = new string[] { "-1" };
            }
            else
            {
                sp = true;
                idP = value;
            }
            return Вид_реставрации();
        }
        [HttpPost]
        public ViewResult Жанр(string[] value, bool clear)
        {
            if (clear)
            {
                sp = false;
                idP = new string[] { "-1" };
            }
            else
            {
                sp = true;
                idP = value;
            }
            return Жанр();
        }
        [HttpPost]
        public ViewResult Зал(string[] value, bool clear)
        {
            if (clear)
            {
                sp = false;
                idP = new string[] { "-1" };
            }
            else
            {
                sp = true;
                idP = value;
            }
            return Зал();
        }
        [HttpPost]
        public ViewResult Материал(string[] value, bool clear)
        {
            if (clear)
            {
                sp = false;
                idP = new string[] { "-1" };
            }
            else
            {
                sp = true;
                idP = value;
            }
            return Материал();
        }
        [HttpPost]
        public ViewResult Место(string[] value, bool clear)
        {
            if (clear)
            {
                sp = false;
                idP = new string[] { "-1" };
            }
            else
            {
                sp = true;
                idP = value;
            }
            return Место();
        }
        [HttpPost]
        public ViewResult Реставрация(string[] value, bool clear)
        {
            if (clear)
            {
                sp = false;
                idP = new string[] { "-1" };
            }
            else
            {
                sp = true;
                idP = value;
            }
            return Реставрация();
        }
        [HttpPost]
        public ViewResult Состояние_картины(string[] value, bool clear)
        {
            if (clear)
            {
                sp = false;
                idP = new string[] { "-1" };
            }
            else
            {
                sp = true;
                idP = value;
            }
            return Состояние_картины();
        }
        [HttpPost]
        public ViewResult Статус_картины(string[] value, bool clear)
        {
            if (clear)
            {
                sp = false;
                idP = new string[] { "-1" };
            }
            else
            {
                sp = true;
                idP = value;
            }
            return Статус_картины();
        }
        [HttpPost]
        public ViewResult Статус_экспозиции(string[] value, bool clear)
        {
            if (clear)
            {
                sp = false;
                idP = new string[] { "-1" };
            }
            else
            {
                sp = true;
                idP = value;
            }
            return Статус_экспозиции();
        }
        [HttpPost]
        public ViewResult Стиль(string[] value, bool clear)
        {
            if (clear)
            {
                sp = false;
                idP = new string[] { "-1" };
            }
            else
            {
                sp = true;
                idP = value;
            }
            return Стиль();
        }
        [HttpPost]
        public ViewResult Страна(string[] value, bool clear)
        {
            if (clear)
            {
                sp = false;
                idP = new string[] { "-1" };
            }
            else
            {
                sp = true;
                idP = value;
            }
            return Страна();
        }
        [HttpPost]
        public ViewResult Техника(string[] value, bool clear)
        {
            if (clear)
            {
                sp = false;
                idP = new string[] { "-1" };
            }
            else
            {
                sp = true;
                idP = value;
            }
            return Техника();
        }
        [HttpPost]
        public ViewResult Экспозиция(string[] value, bool clear)
        {
            if (clear)
            {
                sp = false;
                idP = new string[] { "-1" };
            }
            else
            {
                sp = true;
                idP = value;
            }
            return Экспозиция();
        }
        [HttpPost]
        public ViewResult Экспонат(string[] value, bool clear)
        {
            if (clear)
            {
                sp = false;
                idP = new string[] { "-1" };
            }
            else
            {
                sp = true;
                idP = value;
            }
            return Экспонат();
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
        public RedirectResult Delete(string type)
        {
            try
            {
                switch (type)
                {
                    case "Автор":
                        {
                            foreach (var x in db.Автор.Where(p => idP.Contains(p.Код_автора.ToString())))
                            {
                                db.Автор.Remove(x);
                            }
                            break;
                        }
                    case "Вид_реставрации":
                        {
                            foreach (var x in db.Вид_реставрации.Where(p => idP.Contains(p.Код_вида_реставрации.ToString())))
                            {
                                db.Вид_реставрации.Remove(x);
                            }
                            break;
                        }
                    case "Жанр":
                        {
                            foreach (var x in db.Жанр.Where(p => idP.Contains(p.Код_жанра.ToString())))
                            {
                                db.Жанр.Remove(x);
                            }
                            break;
                        }
                    case "Зал":
                        {
                            db.Зал.Remove(db.Зал.OrderBy(z => z.ЗначениеЗала).Last());
                            break;
                        }
                    case "Картина":
                        {
                            foreach (var x in db.Картина.Where(p => idP.Contains(p.Инвентарный_номер.ToString())))
                            {
                                db.Картина.Remove(x);
                            }
                            break;
                        }
                    case "Материал":
                        {
                            foreach (var x in db.Материал.Where(p => idP.Contains(p.Код_материала.ToString())))
                            {
                                db.Материал.Remove(x);
                            }
                            break;
                        }
                    case "Место":
                        {
                            db.Место.Remove(db.Место.OrderBy(p => p.ЗначениеМеста).Last());
                            break;
                        }
                    case "Реставрация":
                        {
                            foreach (var x in db.Реставрация.Where(p => idP.Contains(p.Код_реставрации.ToString())))
                            {
                                db.Реставрация.Remove(x);
                            }
                            break;
                        }
                    case "Состояние_картины":
                        {
                            foreach (var x in db.Состояние_картины.Where(p => idP.Contains(p.Код_состояния.ToString())))
                            {
                                db.Состояние_картины.Remove(x);
                            }
                            break;
                        }
                    case "Статус_картины":
                        {
                            foreach (var x in db.Статус_картины.Where(p => idP.Contains(p.Код_статуса.ToString())))
                            {
                                db.Статус_картины.Remove(x);
                            }
                            break;
                        }
                    case "Статус_экспозиции":
                        {
                            foreach (var x in db.Статус_экспозиции.Where(p => idP.Contains(p.Код_статуса.ToString())))
                            {
                                db.Статус_экспозиции.Remove(x);
                            }
                            break;
                        }
                    case "Стиль":
                        {
                            foreach (var x in db.Стиль.Where(p => idP.Contains(p.Код_стиля.ToString())))
                            {
                                db.Стиль.Remove(x);
                            }
                            break;
                        }
                    case "Страна":
                        {
                            foreach (var x in db.Страна.Where(p => idP.Contains(p.Код_страны.ToString())))
                            {
                                db.Страна.Remove(x);
                            }
                            break;
                        }
                    case "Техника":
                        {
                            foreach (var x in db.Техника.Where(p => idP.Contains(p.Код_техники.ToString())))
                            {
                                db.Техника.Remove(x);
                            }
                            break;
                        }
                    case "Экспозиция":
                        {
                            foreach (var x in db.Экспозиция.Where(p => idP.Contains(p.Код_экспозиции.ToString())))
                            {
                                db.Экспозиция.Remove(x);
                            }
                            break;
                        }
                    case "Экспонат":
                        {
                            foreach (var x in db.Экспонат.Where(p => idP.Contains(p.Экспозиция.ToString() + " " + p.Место.ToString())))
                            {
                                db.Экспонат.Remove(x);
                            }
                            break;
                        }
                }
                db.SaveChanges();
                idP = new string[] { "-1" };
                sp = false;
                return Redirect("/DBDelete/DeleteSuccessful");
            }
            catch
            {
                idP = new string[] { "-1" };
                sp = false;
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
                isSelected = sp,
                ids = idP
            };
            return View(obj);
        }
        public ViewResult Автор()
        {
            ViewBag.Title = "Delete Author";
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
                isSelected = sp,
                ids = idP
            };
            return View(obj);
        }
        public ViewResult Вид_реставрации()
        {
            ViewBag.Title = "Delete Restoration Type";
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
                isSelected = sp,
                ids = idP
            };
            return View(obj);
        }
        public ViewResult Жанр()
        {
            ViewBag.Title = "Delete Jenre";
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
                isSelected = sp,
                ids = idP
            };
            return View(obj);
        }
        public ViewResult Зал()
        {
            ViewBag.Title = "Delete Room";
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
                isSelected = sp,
                ids = idP
            };
            return View(obj);
        }
        public ViewResult Материал()
        {
            ViewBag.Title = "Delete Material";
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
                isSelected = sp,
                ids = idP
            };
            return View(obj);
        }
        public ViewResult Место()
        {
            ViewBag.Title = "Delete Place";
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
                isSelected = sp,
                ids = idP
            };
            return View(obj);
        }
        public ViewResult Реставрация()
        {
            ViewBag.Title = "Delete Restoration";
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
                isSelected = sp,
                ids = idP
            };
            return View(obj);
        }
        public ViewResult Состояние_картины()
        {
            ViewBag.Title = "Delete Picture conditiob";
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
                isSelected = sp,
                ids = idP
            };
            return View(obj);
        }
        public ViewResult Статус_картины()
        {
            ViewBag.Title = "Delete Peinting statue";
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
                isSelected = sp,
                ids = idP
            };
            return View(obj);
        }
        public ViewResult Статус_экспозиции()
        {
            ViewBag.Title = "Delete Exposition status";
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
                isSelected = sp,
                allEStatus = _StatsE.EStatuses,
                ids = idP
            };
            return View(obj);
        }
        public ViewResult Стиль()
        {
            ViewBag.Title = "Delete Style";
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
                isSelected = sp,
                ids = idP
            };
            return View(obj);
        }
        public ViewResult Страна()
        {
            ViewBag.Title = "Delete Country";
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
                isSelected = sp,
                ids = idP
            };
            return View(obj);
        }
        public ViewResult Техника()
        {
            ViewBag.Title = "Delete Technique";
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
                isSelected = sp,
                ids = idP
            };
            return View(obj);
        }
        public ViewResult Экспозиция()
        {
            ViewBag.Title = "Delete Exposition";
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
                allEStatus = _StatsE.EStatuses,
                isSelected = sp,
                ids = idP
            };
            return View(obj);
        }
        public ViewResult Экспонат()
        {
            ViewBag.Title = "Delete Showpiece";
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
                isSelected = sp,
                ids = idP
            };
            return View(obj);
        }
    }
}
