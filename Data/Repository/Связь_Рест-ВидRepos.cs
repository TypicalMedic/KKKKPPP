using KKKKPPP.Data.Interfaces;
using KKKKPPP.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KKKKPPP.Data.Models.ClientSide;

namespace KKKKPPP.Data.Repository
{
    public class Связь_Рест_ВидRepos : IСвязь_Рест_Вид
    {
        public readonly AppDBContext appDBContext;

        public Связь_Рест_ВидRepos(AppDBContext appDB)
        {
            appDBContext = appDB;
        }
        public IEnumerable<Связь_Рест_Вид> Rest_Types => appDBContext.Связь_Рест_Вид;
    }
}
