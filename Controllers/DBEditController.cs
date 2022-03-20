using KKKKPPP.Data;
using KKKKPPP.Data.Interfaces;
using KKKKPPP.Data.Models;
using KKKKPPP.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace KKKKPPP.Controllers
{
    public class DBEditController : Controller
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
        private static string idP = "-1" ;

        public DBEditController(AppDBContext appDB, IАвтор iA, IТехника iTq, IСостояние iCnd,
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
                idP = "-1" ;
            }
        }
        [HttpPost]
        public dynamic SelectEnt(string value, bool clear, string type)
        {
            if (clear)
            {
                sp = false;
                idP = "-1";
            }
            else
            {
                sp = true;
                idP = value;
            }
            return Redirect(type);
        }
        public ViewResult Картина()
        {
            ViewBag.Title = "Edit Paintings";
            DBEditViewModel obj = new DBEditViewModel
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
                id = idP
            };
            return View(obj);
        }
        public ViewResult Автор()
        {
            ViewBag.Title = "Edit Author";
            DBEditViewModel obj = new DBEditViewModel
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
                id = idP
            };
            return View(obj);
        }
        public ViewResult Вид_реставрации()
        {
            ViewBag.Title = "Edit Restoration Type";
            DBEditViewModel obj = new DBEditViewModel
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
                id = idP
            };
            return View(obj);
        }
        public ViewResult Жанр()
        {
            ViewBag.Title = "Edit Jenre";
            DBEditViewModel obj = new DBEditViewModel
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
                id = idP
            };
            return View(obj);
        }
        public ViewResult Зал()
        {
            ViewBag.Title = "Edit Room";
            DBEditViewModel obj = new DBEditViewModel
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
                id = idP
            };
            return View(obj);
        }
        public ViewResult Материал()
        {
            ViewBag.Title = "Edit Material";
            DBEditViewModel obj = new DBEditViewModel
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
                id = idP
            };
            return View(obj);
        }
        public ViewResult Место()
        {
            ViewBag.Title = "Edit Place";
            DBEditViewModel obj = new DBEditViewModel
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
                id = idP
            };
            return View(obj);
        }
        public ViewResult Реставрация()
        {
            ViewBag.Title = "Edit Restoration";
            DBEditViewModel obj = new DBEditViewModel
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
                id = idP
            };
            return View(obj);
        }
        public ViewResult Состояние_картины()
        {
            ViewBag.Title = "Edit Picture conditiob";
            DBEditViewModel obj = new DBEditViewModel
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
                id = idP
            };
            return View(obj);
        }
        public ViewResult Статус_картины()
        {
            ViewBag.Title = "Edit Peinting statue";
            DBEditViewModel obj = new DBEditViewModel
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
                id = idP
            };
            return View(obj);
        }
        public ViewResult Статус_экспозиции()
        {
            ViewBag.Title = "Edit Exposition status";
            DBEditViewModel obj = new DBEditViewModel
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
                id = idP
            };
            return View(obj);
        }
        public ViewResult Стиль()
        {
            ViewBag.Title = "Edit Style";
            DBEditViewModel obj = new DBEditViewModel
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
                id = idP
            };
            return View(obj);
        }
        public ViewResult Страна()
        {
            ViewBag.Title = "Edit Country";
            DBEditViewModel obj = new DBEditViewModel
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
                id = idP
            };
            return View(obj);
        }
        public ViewResult Техника()
        {
            ViewBag.Title = "Edit Technique";
            DBEditViewModel obj = new DBEditViewModel
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
                id = idP
            };
            return View(obj);
        }
        public ViewResult Экспозиция()
        {
            ViewBag.Title = "Edit Exposition";
            DBEditViewModel obj = new DBEditViewModel
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
                id = idP
            };
            return View(obj);
        }
        public ViewResult Экспонат()
        {
            ViewBag.Title = "Edit Showpiece";
            DBEditViewModel obj = new DBEditViewModel
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
                id = idP
            };
            return View(obj);
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<RedirectResult> FinishEditAsync(Картина pic, int[] materials, int[] rtypes, Автор au, Вид_реставрации rt, Жанр j, Зал z, Материал m, Место p, Реставрация r, Состояние_картины spp,
            Статус_картины stp, Статус_экспозиции ste, Стиль st, Страна c, Техника t, Экспозиция e, Экспонат sh, string type, IFormFile PicFile)
        {
            try
            {
                switch (type)
                {
                    case "Автор":
                        {
                            db.Entry(au).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                            break;
                        }
                    case "Вид_реставрации":
                        {
                            db.Entry(rt).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                            break;
                        }
                    case "Жанр":
                        {
                            db.Entry(j).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                            break;
                        }
                    case "Зал":
                        {
                            db.Entry(z).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                            break;
                        }
                    case "Картина":
                        {
                            if(PicFile != null)
                            {
                                string path = "wwwroot/img/Pictures/" + pic.ЦифроваяВерсия;
                                using (var fileStream = new FileStream(path, FileMode.Create))
                                {
                                    await PicFile.CopyToAsync(fileStream);
                                }
                            }
                            List<int> materialsL = materials.ToList();
                            foreach (var x in db.Связь_Материал_Картина.Where(m => m.Картина == pic.Инвентарный_номер))
                            {
                                if (!materialsL.Contains(x.Материал))
                                {
                                    db.Связь_Материал_Картина.Remove(x);
                                }
                                else
                                {
                                    materialsL.Remove(x.Материал);
                                }
                            }
                            foreach (var x in materialsL)
                            {
                                Связь_Материал_Картина newC = new Связь_Материал_Картина { Материал = x, Картина = pic.Инвентарный_номер };
                                db.Связь_Материал_Картина.Add(newC);
                            }
                            db.Entry(pic).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                            break;
                        }
                    case "Материал":
                        {
                            db.Entry(m).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                            break;
                        }
                    case "Место":
                        {
                            db.Entry(p).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                            break;
                        }
                    case "Реставрация":
                        {
                            List<int> rtt = rtypes.ToList();
                            foreach (var x in db.Связь_Рест_Вид.Where(m => m.Код_реставрации == r.Код_реставрации))
                            {
                                if (!rtt.Contains(x.Вид_реставрации))
                                {
                                    db.Связь_Рест_Вид.Remove(x);
                                }
                                else
                                {
                                    rtt.Remove(x.Вид_реставрации);
                                }
                            }
                            foreach (var x in rtt)
                            {
                                Связь_Рест_Вид newC = new  Связь_Рест_Вид{ Вид_реставрации = x, Код_реставрации = r.Код_реставрации };
                                db.Связь_Рест_Вид.Add(newC);
                            }
                            db.Entry(r).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                            break;
                        }
                    case "Состояние_картины":
                        {
                            db.Entry(spp).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                            break;
                        }
                    case "Статус_картины":
                        {
                            db.Entry(stp).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                            break;
                        }
                    case "Статус_экспозиции":
                        {
                            db.Entry(ste).State = Microsoft.EntityFrameworkCore.EntityState.Modified; 
                            break;
                        }
                    case "Стиль":
                        {
                            db.Entry(st).State = Microsoft.EntityFrameworkCore.EntityState.Modified; 
                            break;
                        }
                    case "Страна":
                        {
                            db.Entry(c).State = Microsoft.EntityFrameworkCore.EntityState.Modified; 
                            break;
                        }
                    case "Техника":
                        {
                            db.Entry(t).State = Microsoft.EntityFrameworkCore.EntityState.Modified; 
                            break;
                        }
                    case "Экспозиция":
                        {
                            db.Entry(e).State = Microsoft.EntityFrameworkCore.EntityState.Modified; 
                            break;
                        }
                    case "Экспонат":
                        {
                            db.Entry(sh).State = Microsoft.EntityFrameworkCore.EntityState.Modified; 
                            break;
                        }
                }
                idP =  "-1";
                sp = false;
                db.SaveChanges();
                return Redirect("EditSuccessful");
            }
            catch
            {
                return Redirect("EditUnsuccessful");
            }
        }
        public ViewResult EditSuccessful()
        {
            ViewBag.Title = "Edit Successful";
            return View();
        }
        public ViewResult DBEdit()
        {
            ViewBag.Title = "Edit Element";
            DBEditViewModel obj = new DBEditViewModel
            {
                allEntities = _Entities.Entities
            };
            return View(obj);
        }
    }
}
