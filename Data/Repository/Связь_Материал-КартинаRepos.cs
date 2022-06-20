using KKKKPPP.Data.Interfaces;
using KKKKPPP.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KKKKPPP.Data.Models.ClientSide;

namespace KKKKPPP.Data.Repository
{
    public class Связь_Материал_КартинаRepos : IСвязь_Материал_Картина
    {
        public readonly AppDBContext appDBContext;

        public Связь_Материал_КартинаRepos(AppDBContext appDB)
        {
            appDBContext = appDB;
        }
        public IEnumerable<Связь_Материал_Картина> Pic_Material => appDBContext.Связь_Материал_Картина;
    }
}
