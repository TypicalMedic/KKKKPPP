using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace KKKKPPP.Data.Models
{
    public class Состояние_картины
    {
        [Key]
        public int Код_состояния { get; set; }
        public string Состояние { get; set; }
    }
}
