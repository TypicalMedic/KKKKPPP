using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace KKKKPPP.Data.Models
{
    public class Место
    {
        [Key]
        public int Номер_места { get;  set; }
        public int Зал { get; set; }
        public int ЗначениеМеста { get; set; }
    }
}
