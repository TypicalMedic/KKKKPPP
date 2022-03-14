using KKKKPPP.Data.Interfaces;
using KKKKPPP.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KKKKPPP.Data.Repository
{
    public class СтатусЭкспозицииRepos : IСтатусЭкспозиции
    {
        public readonly AppDBContext appDBContext;

        public СтатусЭкспозицииRepos(AppDBContext appDB)
        {
            appDBContext = appDB;
        }
        public IEnumerable<Статус_экспозиции> EStatuses => appDBContext.Статус_экспозиции;
    }
}
