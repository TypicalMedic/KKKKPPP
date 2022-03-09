using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KKKKPPP.Data.Models
{
    public class Вид_реставрации
    {
        [Key]
        public int Код_вида_реставрации { get; set; }
        public string ВидРеставрации { get; set; }
    }
}
