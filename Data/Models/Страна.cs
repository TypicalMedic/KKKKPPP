using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace KKKKPPP.Data.Models
{
    public class Страна
    {
        [Key]
        public int Код_страны { get;set; }
        public string НазваниеСтраны { get; set; }
    }
}
