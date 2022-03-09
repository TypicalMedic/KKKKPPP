using KKKKPPP.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KKKKPPP.Data.Interfaces
{
    public interface IСвязь_Рест_Вид
    {
        IEnumerable<Связь_Рест_Вид> Rest_Types { get; }
    }
}
