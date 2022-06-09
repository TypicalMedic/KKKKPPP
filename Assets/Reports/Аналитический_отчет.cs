using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KKKKPPP.Data
{
    public class Аналитический_отчет
    {
        [Key]
        public int Инвентарный_номер { get; set; }
        public int Код_состояния_картины { get; set; }
    }
}
