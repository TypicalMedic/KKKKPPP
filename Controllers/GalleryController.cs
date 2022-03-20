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
using System.Speech.Synthesis;

namespace KKKKPPP.Controllers
{
    public class GalleryController : Controller
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
        private readonly IЭкскурсия _Excurs;
        private readonly IЭкспонат _Showp;
        private readonly IЭкспозиция _Expos;
        private readonly IЗал _Rooms;
        private readonly IМесто _Places;
        private readonly AppDBContext db;
        private static bool sp = false;
        private static string idP = "-1";
        static SpeechSynthesizer synth = new SpeechSynthesizer();

        public GalleryController(AppDBContext appDB, IАвтор iA, IТехника iTq, IСостояние iCnd,
            IСтатусКартины iStp, IСтатусЭкспозиции iSte, IСтрана iCt, IЖанр iJ, IСтиль iSt, IСущности iSu, IКартина iPc,
            IРеставрация iR, IСвязь_Материал_Картина iMP, IСвязь_Рест_Вид iRT, IМатериал iM, IВид_реставрации iRtp,
            IМесто iPl, IЗал iRm, IЭкспозиция iEx, IЭкспонат iSh, IЭкскурсия iExc)
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
            _Excurs = iExc;
            db = appDB;
            if (!sp)
            {
                idP = "-1";
            }
        }
        [HttpPost]
        public dynamic SelectExpo(string value)
        {

            return Redirect("ShowExpo?id=" + value);
        }
        public ViewResult ShowExpo(string id)
        {
            ViewBag.Title = "View exposition";
            GalleryViewModel obj = new GalleryViewModel
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
                id = id
            };
            return View(obj);

        }
        public ViewResult FinishExcursion()
        {
            ViewBag.Title = "End of excursion!";
            return View();

        }

        public IActionResult Index()
        {
            return View();
        }

        public ViewResult Expositions()
        {
            ViewBag.Title = "View expositions";
            GalleryViewModel obj = new GalleryViewModel
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
                id = idP
            };
            return View(obj);
        }
        public ViewResult Excursions()
        {
            ViewBag.Title = "Go on an excursion!";
            GalleryViewModel obj = new GalleryViewModel
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
                allExcurs = _Excurs.Excursions,
                id = idP
            };
            return View(obj);
        }
        public ViewResult ExcursionFlow(string value, int picIndex, int roomIndex)
        {
            ViewBag.Title = "Go on an excursion!";
            GalleryViewModel obj = new GalleryViewModel
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
                allExcurs = _Excurs.Excursions,
                id = value,
                exc = db.Экскурсия.FirstOrDefault(e => e.id == int.Parse(value))
            };
            obj.exc.ImportJSON();
            if (picIndex < 0)
            {
                roomIndex--;
                if (roomIndex >= 0)
                {
                    picIndex = ((List<Dictionary<string, string>>)obj.exc.content[roomIndex]["textList"]).Count - 1;
                }
                else
                {
                    picIndex = -1;
                }

            }
            if (roomIndex >= 0 && ((List<Dictionary<string, string>>)obj.exc.content[roomIndex]["textList"]).Count <= picIndex)
            {
                picIndex = 0;
                roomIndex++;
            }
            obj.excFlowIndex = picIndex;
            obj.roomFlowIndex = roomIndex;
            return View(obj);
        }
        public void ReadText(string text)
        {
            // Configure the audio output.   
            synth.SetOutputToDefaultAudioDevice();
            // Speak a string.  
            synth.Speak(text);
        }
        [HttpPost]
        public RedirectResult ChangeShowpiece(string value, int pIndex, int rIndex, string type, string text)
        {
            synth.Pause();
            synth = new SpeechSynthesizer();
            switch (type)
            {
                case "next":
                    {
                        if (rIndex < 0)
                        {
                            rIndex++;
                            pIndex = -1;
                        }
                        return Redirect($"ExcursionFlow?value={value}&picIndex={pIndex + 1}&roomIndex={rIndex}");
                    }
                case "prev":
                    {
                        return Redirect($"ExcursionFlow?value={value}&picIndex={pIndex - 1}&roomIndex={rIndex}");
                    }
                case "end":
                    {
                        return Redirect("FinishExcursion");
                    }
                case "read":
                    {
                        ReadText(text);
                        return Redirect($"ExcursionFlow?value={value}&picIndex={pIndex}&roomIndex={rIndex}");
                    }
                default:
                    {
                        return null;
                    }
            }
        }
    }
}
