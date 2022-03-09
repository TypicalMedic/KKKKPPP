using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace KKKKPPP.Data.Models
{
    public class Техника
    {
        [Key]
        public int Код_техники { get;set; }
        public string НазваниеТехники { get; set; }
    }
}
