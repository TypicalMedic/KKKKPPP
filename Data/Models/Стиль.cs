using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace KKKKPPP.Data.Models
{
    public class Стиль
    {
        [Key]
        public int Код_стиля { get; set;  }
        public string НазваниеСтиля { get; set; }
    }
}
