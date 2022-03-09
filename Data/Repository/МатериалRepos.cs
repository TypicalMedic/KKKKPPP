using KKKKPPP.Data.Interfaces;
using KKKKPPP.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KKKKPPP.Data.Repository
{
    public class МатериалRepos : IМатериал
    {
        public readonly AppDBContext appDBContext;

        public МатериалRepos(AppDBContext appDB)
        {
            appDBContext = appDB;
        }
        public IEnumerable<Материал> Materials => appDBContext.Материал;
    }
}
