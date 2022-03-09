using KKKKPPP.Data.Interfaces;
using KKKKPPP.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KKKKPPP.Data.Repository
{
    public class СтатусКартиныRepos : IСтатусКартины
    {
        public readonly AppDBContext appDBContext;

        public СтатусКартиныRepos(AppDBContext appDB)
        {
            appDBContext = appDB;
        }
        public IEnumerable<Статус_картины> Statuses => appDBContext.Статус_картины;
    }
}
