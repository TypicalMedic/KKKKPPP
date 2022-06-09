using KKKKPPP.Data;
using KKKKPPP.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KKKKPPP.ViewModels
{
    public class AccountViewModel 
    { 
        public IEnumerable<Экспозиция> allExpos { get; set; }
        public IEnumerable<Экскурсия> allExcurs { get; set; }
        public string ErrorMessage  { get; set; }
    }
}
