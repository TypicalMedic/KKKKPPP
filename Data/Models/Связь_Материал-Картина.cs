using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KKKKPPP.Data.Models
{
    //[Keyless]
    public class Связь_Материал_Картина
    {

        public int Материал { get; set; }
        public int Картина { get; set; }
    }
}
