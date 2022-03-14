using KKKKPPP.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KKKKPPP.ViewModels
{
    public class DBQueryViewModel
    {
        public IEnumerable<Автор> allAuthors { get; set; }
        public IEnumerable<Техника> allTechniques { get; set; }
        public IEnumerable<Состояние_картины> allCondit { get; set; }
        public IEnumerable<Статус_картины> allStatus { get; set; }
        public IEnumerable<Страна> allCountries { get; set; }
        public IEnumerable<Жанр> allJanres { get; set; }
        public IEnumerable<Стиль> allStyles { get; set; }
        public IEnumerable<string> allEntities { get; set; }
        public IEnumerable<Type> allEntityTypes { get; set; }
        public IEnumerable<Картина> allPictures { get; set; }
        public IEnumerable<Материал> allMaterials { get; set; }
        public IEnumerable<Реставрация> allRestorations { get; set; }
        public IEnumerable<Вид_реставрации> allRestorationTypes { get; set; }
        public IEnumerable<Связь_Рест_Вид> allRest_Types { get; set; }
        public IEnumerable<Связь_Материал_Картина> allPic_Materials { get; set; }
        public IEnumerable<Экспозиция> allExpos { get; set; }
        public IEnumerable<Экспонат> allShowpieces { get; set; }
        public IEnumerable<Место> allPlaces { get; set; }
        public IEnumerable<Зал> allRooms { get; set; }
        public string selEnt { get; set; }
        public List<List<string>> queryResult { get; set; }
    }
}
