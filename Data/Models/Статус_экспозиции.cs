using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace KKKKPPP.Data.Models
{
    public class Статус_экспозиции
    {
        [Key]
        public int Код_статуса { get;  set; }
        public string Статус { get; set; }
    }
}
