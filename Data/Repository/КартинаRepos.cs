using KKKKPPP.Data.Interfaces;
using KKKKPPP.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KKKKPPP.Data.Repository
{
    public class КартинаRepos : IКартина
    {
        public readonly AppDBContext appDBContext;

        public КартинаRepos(AppDBContext appDB)
        {
            appDBContext = appDB;
        }
        public IEnumerable<Картина> Pictures => appDBContext.Картина;
    }
}
