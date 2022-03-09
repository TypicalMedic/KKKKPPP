using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace KKKKPPP.Data.Models
{
    public class Автор
    {
        [Key]
        public int Код_автора { get;set; }
        public string ФИО { get; set; }
        public int ГодРождения { get; set; }
        public int ГодСмерти { get; set; }
        public int Код_страны_рождения { get; set; }
    }
}
