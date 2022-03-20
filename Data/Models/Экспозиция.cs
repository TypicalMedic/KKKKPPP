using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace KKKKPPP.Data.Models
{
    public class Экспозиция
    {
        [Key]
        public int Код_экспозиции { get; set;}
        public string Название { get; set; }
        public int Статус { get; set; }
        public DateTime ДатаОткрытия { get; set; }
        public DateTime? ДатаЗакрытия { get; set; }
        public string Аннотация { get; set; }
        public string Пресс_релиз { get; set; }
    }
}
