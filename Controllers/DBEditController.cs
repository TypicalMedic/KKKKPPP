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
    public class DBEditController : Controller
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
        private int idP = -1;

        public DBEditController(IАвтор authors, IТехника techs, IСостояние conds, IСтатусКартины statsP,
            IСтрана countries, IЖанр janres, IСтиль styles, IСущности entities, IКартина pictures,
            IМатериал materials, IРеставрация restorations, IСвязь_Материал_Картина pic_Materials,
            IСвязь_Рест_Вид rest_Types, IВид_реставрации restorationTypes, IЭкспонат showp, IЭкспозиция expos,
            IЗал rooms, IМесто places, AppDBContext db)
        {
            _Authors = authors;
            _Techs = techs;
            _Conds = conds;
            _StatsP = statsP;
            _Countries = countries;
            _Janres = janres;
            _Styles = styles;
            _Entities = entities;
            _Pictures = pictures;
            _Materials = materials;
            _Restorations = restorations;
            _Pic_Materials = pic_Materials;
            _Rest_Types = rest_Types;
            _RestorationTypes = restorationTypes;
            _Showp = showp;
            _Expos = expos;
            _Rooms = rooms;
            _Places = places;
            this.db = db;
        }
        [HttpPost]
        public ViewResult Картина(int value, bool clear)
        {
            if (clear)
            {
                sp = false;
                idP = -1;
            }
            else
            {
                sp = true;
                idP = value;
            }
            return Картина();
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
                isPicSelected = sp,
                idPic = idP
            };
            return View(obj);
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public RedirectResult FinishEdit(Картина pic, int[] materials)
        {
            //try
            //{
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
            db.SaveChanges();
            return Redirect("EditSuccessful");
            //}
            //catch
            //{
            //    return Redirect("EditUnsuccessful");
            //}
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
