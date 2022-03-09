using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace KKKKPPP.Data.Models
{
    //[Keyless]
    public class Экспонат
    {
        public int Экспозиция { get; set; }
        public int Место { get; set; }
        public int Картина { get; set; }
        public string Этикетаж { get; set; }
    }
}
