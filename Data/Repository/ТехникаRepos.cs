using KKKKPPP.Data.Interfaces;
using KKKKPPP.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KKKKPPP.Data.Repository
{
    public class ТехникаRepos : IТехника
    {
        public readonly AppDBContext appDBContext;

        public ТехникаRepos(AppDBContext appDB)
        {
            appDBContext = appDB;
        }
        public IEnumerable<Техника> Techniques => appDBContext.Техника;
    }
}
