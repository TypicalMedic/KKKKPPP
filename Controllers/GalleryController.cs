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
using Microsoft.AspNetCore.Authorization;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Unicode;

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
        static SpeechSynthesizer synth = new SpeechSynthesizer();
        static Экскурсия exc = new Экскурсия { content = new List<List<Dictionary<string, string>>> { new List<Dictionary<string, string>>() }, Тип = "User", Название = "", Аннотация = "", Содержание = "" };

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
        }
        [Authorize]
        [HttpPost]
        public IActionResult LikeExpo(string id, string act)
        {
            if (act == "like")
            {
                UserViewModel.userInfo.LikedExpos.Add(int.Parse(id));
                db.LikeExpo.Add(new LikeExpo { ExpoId = int.Parse(id), UserId = UserViewModel.userInfo.Id });
                db.SaveChanges();
            }
            else
            {
                UserViewModel.userInfo.LikedExpos.Remove(int.Parse(id));
                db.LikeExpo.Remove(new LikeExpo { ExpoId = int.Parse(id), UserId = UserViewModel.userInfo.Id });
                db.SaveChanges();
            }
            return Redirect(Request.Headers["Referer"].ToString());
        }
        [Authorize]
        [HttpPost]
        public IActionResult LikeExcur(string id, string act)
        {
            if (act == "like")
            {
                UserViewModel.userInfo.LikedExcurs.Add(int.Parse(id));
                db.LikeExcur.Add(new LikeExcur { ExcurId = int.Parse(id), UserId = UserViewModel.userInfo.Id });
                db.SaveChanges();
            }
            else
            {
                UserViewModel.userInfo.LikedExcurs.Remove(int.Parse(id));
                db.LikeExcur.Remove(new LikeExcur { ExcurId = int.Parse(id), UserId = UserViewModel.userInfo.Id });
                db.SaveChanges();
            }
            return Redirect(Request.Headers["Referer"].ToString());
        }
        [HttpPost]
        public IActionResult LeaveCommentExpo(string id, string comment)
        {
            using (SqlConnection connection = new SqlConnection(db.Database.GetConnectionString()))
            {

                string sql = "Insert Into CommentExpo Values(" + id + ", " + UserViewModel.userInfo.Id + ", '" + comment + "');";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }

            return Redirect(Request.Headers["Referer"].ToString());
        }
        [HttpPost]
        public IActionResult LeaveCommentExcur(string id, string comment)
        {
            using (SqlConnection connection = new SqlConnection(db.Database.GetConnectionString()))
            {

                string sql = "Insert Into CommentExcur Values(" + id + ", " + UserViewModel.userInfo.Id + ", '" + comment + "', convert(datetime, '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "', 20));";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }

            return Redirect(Request.Headers["Referer"].ToString());
        }
        public ViewResult ShowExpo(string id)
        {
            ViewBag.Title = "View exposition";
            GalleryViewModel obj = new GalleryViewModel
            {
                allAuthors = _Authors.Authors,
                allCountries = _Countries.Countries,
                allPictures = _Pictures.Pictures,
                allExpos = _Expos.Expos,
                allShowpieces = _Showp.Showpieces,
                allExpoComments = db.CommentExpo,
                allUsers = db.User,
                allExpoLikes = db.LikeExpo,
                id = id
            };
            return View(obj);

        }
        public ViewResult FinishExcursion()
        {
            ViewBag.Title = "End of excursion!";
            return View();

        }
        public ViewResult CreateExcursion()
        {
            GalleryViewModel obj = new GalleryViewModel
            {
                allAuthors = _Authors.Authors,
                allCountries = _Countries.Countries,
                allPictures = _Pictures.Pictures,
                allExpos = _Expos.Expos,
                allShowpieces = _Showp.Showpieces,
                allExpoComments = db.CommentExpo,
                allRooms = _Rooms.Rooms,
                exc = exc
            };
            return View(obj);
        }
        [HttpPost]
        public ViewResult EditExcur(string action, int excId, int roomId, int picId, string title, string text, int[] pics)
        {
            if (excId > 0)
            {
                exc = db.Экскурсия.FirstOrDefault(e => e.id == excId);
                exc.ImportJSON();
            }
            else
            {
                if (action != "changeRoom")
                {
                    string pcs = "";
                    foreach (int x in pics)
                    {
                        pcs += x.ToString() + ",";
                    }
                    pcs.Trim(',');
                    exc.content[roomId][picId] = new Dictionary<string, string> { { "title", title }, { "text", text }, { "picNo", pcs } };
                }

            }
            GalleryViewModel obj = new GalleryViewModel
            {
                allAuthors = _Authors.Authors,
                allCountries = _Countries.Countries,
                allPictures = _Pictures.Pictures,
                allExpos = _Expos.Expos,
                allShowpieces = _Showp.Showpieces,
                allExpoComments = db.CommentExpo,
                allRooms = _Rooms.Rooms,
                exc = exc,
                roomFlowIndex = roomId,
                excFlowIndex = picId
            };
            return View(obj);
        }
        public IActionResult FinishEdit(string action, string name, string annotation)
        {
            if (action == "delete")
            {
                exc = new Экскурсия { content = new List<List<Dictionary<string, string>>> { new List<Dictionary<string, string>>() }, Тип = "User", Название = "", Аннотация = "", Содержание = "" };
                return Redirect("/Account/UserAccount");

            }
            exc.Название = name;
            exc.Аннотация = annotation;
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };
            string jsonString = JsonSerializer.Serialize(exc.content, options);
            string path = "Assets/Excursions/" + exc.Содержание;
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
            System.IO.File.WriteAllText($"Assets/Excursions/{exc.Название}-{exc.id}.json", jsonString);
            exc.Содержание = exc.Название + "-" + exc.id + ".json";
            db.Entry(exc).State = EntityState.Modified;
            db.SaveChanges();
            exc = new Экскурсия { content = new List<List<Dictionary<string, string>>> { new List<Dictionary<string, string>>() }, Тип = "User", Название = "", Аннотация = "", Содержание = "" };
            return Redirect("/Account/UserAccount");
        }

        public IActionResult FinishAdd(string action, string name, string annotation)
        {
            if (action == "delete")
            {
                exc = new Экскурсия { content = new List<List<Dictionary<string, string>>> { new List<Dictionary<string, string>>() }, Тип = "User", Название = "", Аннотация = "", Содержание = "" };
                return Redirect("/Account/UserAccount");

            }
            exc.Тип += $"-{UserViewModel.userInfo.Id}-";
            exc.Название = name;
            exc.Аннотация = annotation;
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };
            string jsonString = JsonSerializer.Serialize(exc.content, options);
            System.IO.File.WriteAllText($"Assets/Excursions/{exc.Название}-{exc.id}.json", jsonString);
            exc.Содержание = exc.Название + "-" + exc.id + ".json";
            db.Экскурсия.Add(exc);
            db.SaveChanges();
            exc = new Экскурсия { content = new List<List<Dictionary<string, string>>> { new List<Dictionary<string, string>>() }, Тип = "User", Название = "", Аннотация = "", Содержание = "" };
            return Redirect("/Account/UserAccount");
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddPart(int room, string title, string text, int[] pics, string action)
        {
            if (action == "addRoom")
            {
                exc.content.Add(new List<Dictionary<string, string>>());
                return Redirect("CreateExcursion");
            }
            string pcs = "";
            foreach (int x in pics)
            {
                pcs += x.ToString() + ",";
            }
            pcs.Trim(',');
            exc.content[room - 1].Add(new Dictionary<string, string> { { "title", title }, { "text", text }, { "picNo", pcs } });
            return Redirect("CreateExcursion");
        }
        public ViewResult Expositions()
        {
            ViewBag.Title = "View expositions";
            GalleryViewModel obj = new GalleryViewModel
            {
                allExpos = _Expos.Expos
            };
            return View(obj);
        }
        public ViewResult Excursions()
        {
            ViewBag.Title = "Go on an excursion!";
            GalleryViewModel obj = new GalleryViewModel
            {
                allExcurs = _Excurs.Excursions,
                allUsers = db.User
            };
            return View(obj);
        }
        public ViewResult ExcursionPreview(string id)
        {
            GalleryViewModel obj = new GalleryViewModel
            {
                allExcurComments = db.CommentExcur,
                allUsers = db.User,
                allExcurLikes = db.LikeExcur,
                id = id,
                exc = db.Экскурсия.FirstOrDefault(e => e.id == int.Parse(id))
            };
            return View(obj);
        }
        public ViewResult ExcursionFlow(string value, int picIndex, int roomIndex)
        {
            ViewBag.Title = "Go on an excursion!";
            GalleryViewModel obj = new GalleryViewModel
            {
                allAuthors = _Authors.Authors,
                allCountries = _Countries.Countries,
                allPictures = _Pictures.Pictures,
                allExcurs = _Excurs.Excursions,
                id = value,
                exc = db.Экскурсия.FirstOrDefault(e => e.id == int.Parse(value))
            };
            if (synth.State == SynthesizerState.Paused || synth.State == SynthesizerState.Ready)
            {
                obj.isReading = false;
            }
            else
            {
                obj.isReading = true;
            }
            obj.exc.ImportJSON();
            if (picIndex < 0)
            {
                roomIndex--;
                picIndex = obj.exc.content[roomIndex].Count - 1;

            }
            if (roomIndex >= 0 && obj.exc.content[roomIndex].Count <= picIndex)
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
            synth.SpeakAsync(text);
        }
        [HttpPost]
        public RedirectResult ChangeShowpiece(string value, int pIndex, int rIndex, string type, string text)
        {
            switch (type)
            {
                case "next":
                    {
                        synth.Pause();
                        synth = new SpeechSynthesizer();
                        return Redirect($"ExcursionFlow?value={value}&picIndex={pIndex + 1}&roomIndex={rIndex}");
                    }
                case "prev":
                    {
                        synth.Pause();
                        synth = new SpeechSynthesizer();
                        return Redirect($"ExcursionFlow?value={value}&picIndex={pIndex - 1}&roomIndex={rIndex}");
                    }
                case "end":
                    {
                        synth.Pause();
                        synth = new SpeechSynthesizer();
                        return Redirect("FinishExcursion");
                    }
                case "read":
                    {
                        if (synth.State == SynthesizerState.Ready)
                        {
                            ReadText(text);
                        }
                        else
                        {
                            synth.Resume();
                        }
                        return Redirect($"ExcursionFlow?value={value}&picIndex={pIndex}&roomIndex={rIndex}");
                    }
                case "pause":
                    {
                        synth.Pause();
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
