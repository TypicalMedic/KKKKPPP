using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace KKKKPPP.Data.Models
{
    public class Зал
    {
        [Key]
        public int Номер_зала { get; set; }
        public uint Этаж { get; set; }
    }
}
