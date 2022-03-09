using KKKKPPP.Data.Interfaces;
using KKKKPPP.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KKKKPPP.Data.Repository
{
    public class ЭкспозицияRepos : IЭкспозиция
    {
        public readonly AppDBContext appDBContext;

        public ЭкспозицияRepos(AppDBContext appDB)
        {
            appDBContext = appDB;
        }
        public IEnumerable<Экспозиция> Expos => appDBContext.Экспозиция;
    }
}
