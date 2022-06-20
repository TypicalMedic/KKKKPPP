using KKKKPPP.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KKKKPPP.Data.Models.ClientSide;

namespace KKKKPPP.ViewModels
{
    public class DBViewViewModel
    {
        public IEnumerable<Автор> allАвтор { get; set; }
        public IEnumerable<Техника> allТехника { get; set; }
        public IEnumerable<Состояние_картины> allСостояние_картины { get; set; }
        public IEnumerable<Статус_картины> allСтатус_картины { get; set; }
      //  public IEnumerable<Статус_экспозиции> allСтатус_экспозиции { get; set; }
        public IEnumerable<Страна> allСтрана { get; set; }
        public IEnumerable<Жанр> allЖанр { get; set; }
        public IEnumerable<Стиль> allСтиль { get; set; }
        public IEnumerable<string> allEntities { get; set; }
        public IEnumerable<Type> allEntityTypes { get; set; }
        public IEnumerable<Картина> allКартина { get; set; }
        public IEnumerable<Материал> allМатериал { get; set; }
        public IEnumerable<Реставрация> allРеставрация { get; set; }
        public IEnumerable<Вид_реставрации> allВид_реставрации { get; set; }
        public IEnumerable<Связь_Рест_Вид> allСвязь_Рест_Вид { get; set; }
        public IEnumerable<Связь_Материал_Картина> allСвязь_Материал_Картина { get; set; }
        public IEnumerable<Экспозиция> allЭкспозиция { get; set; }
        public IEnumerable<Экспонат> allЭкспонат { get; set; }
        public IEnumerable<Место> allМесто { get; set; }
        public IEnumerable<Зал> allЗал { get; set; }
        public string selType { get; set; }
       // public List<Реставрация> addedRestorations { get; set; }
    }
}
