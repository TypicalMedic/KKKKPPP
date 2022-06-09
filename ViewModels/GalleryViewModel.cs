using KKKKPPP.Data;
using KKKKPPP.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KKKKPPP.ViewModels
{
    public class GalleryViewModel
    {
        public IEnumerable<Автор> allAuthors { get; set; }
        public IEnumerable<Техника> allTechniques { get; set; }
        public IEnumerable<Состояние_картины> allCondit { get; set; }
        public IEnumerable<Статус_картины> allStatus { get; set; }
        //   public IEnumerable<Статус_экспозиции> allEStatus { get; set; }
        public IEnumerable<Страна> allCountries { get; set; }
        public IEnumerable<Жанр> allJanres { get; set; }
        public IEnumerable<Стиль> allStyles { get; set; }
        public IEnumerable<Картина> allPictures { get; set; }
        public IEnumerable<Материал> allMaterials { get; set; }
        public IEnumerable<Реставрация> allRestorations { get; set; }
        public IEnumerable<Вид_реставрации> allRestorationTypes { get; set; }
        public IEnumerable<Связь_Рест_Вид> allRest_Types { get; set; }
        public IEnumerable<Связь_Материал_Картина> allPic_Materials { get; set; }
        public IEnumerable<Экспозиция> allExpos { get; set; }
        public IEnumerable<Экскурсия> allExcurs { get; set; }
        public IEnumerable<Экспонат> allShowpieces { get; set; }
        public IEnumerable<Место> allPlaces { get; set; }
        public IEnumerable<Зал> allRooms { get; set; }
        public IEnumerable<string> allEntities { get; set; }
        public IEnumerable<User> allUsers { get; set; }
        public IEnumerable<CommentExpo> allExpoComments { get; set; }
        public IEnumerable<CommentExcur> allExcurComments { get; set; }
        public IEnumerable<LikeExcur> allExcurLikes { get; set; }
        public IEnumerable<LikeExpo> allExpoLikes { get; set; }
        public string id { get; set; }
        public int excFlowIndex { get; set; }
        public int roomFlowIndex { get; set; }
        public bool isReading { get; set; }
        public Экскурсия exc { get; set; }
    }
}
