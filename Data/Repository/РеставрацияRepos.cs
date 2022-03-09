using KKKKPPP.Data.Interfaces;
using KKKKPPP.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KKKKPPP.Data.Repository
{
    public class РеставрацияRepos : IРеставрация
    {
        public readonly AppDBContext appDBContext;

        public РеставрацияRepos(AppDBContext appDB)
        {
            appDBContext = appDB;
        }
        public IEnumerable<Реставрация> Restorations => appDBContext.Реставрация;
    }
}
