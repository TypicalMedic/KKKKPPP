using KKKKPPP.Data.Interfaces;
using KKKKPPP.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KKKKPPP.Data.Repository
{
    public class МестоRepos : IМесто
    {
        public readonly AppDBContext appDBContext;

        public МестоRepos(AppDBContext appDB)
        {
            appDBContext = appDB;
        }
        public IEnumerable<Место> Places => appDBContext.Место;
    }
}
