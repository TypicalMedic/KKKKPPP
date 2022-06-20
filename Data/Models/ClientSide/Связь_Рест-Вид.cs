using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KKKKPPP.Data.Models.ClientSide
{
    //[Keyless]
    public class Связь_Рест_Вид
    {
        public int Код_реставрации { get; set; }
        public int Вид_реставрации { get; set; }
    }
}
