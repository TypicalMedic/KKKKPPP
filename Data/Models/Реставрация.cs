using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace KKKKPPP.Data.Models
{
    public class Реставрация
    {
        [Key]
        public int Код_реставрации { get; set; }
        public int Картина { get; set; }
        public DateTime ДатаРеставрации { get; set; }
    }
}
