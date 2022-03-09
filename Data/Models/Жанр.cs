using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace KKKKPPP.Data.Models
{
    public class Жанр
    {
        [Key]
        public int Код_жанра { get; set; }
        public string НазваниеЖанра { get; set; }
    }
}
