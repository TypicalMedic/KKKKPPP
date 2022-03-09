using KKKKPPP.Data.Interfaces;
using KKKKPPP.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KKKKPPP.Data.Repository
{
    public class ЭкспонатRepos : IЭкспонат
    {
        public readonly AppDBContext appDBContext;

        public ЭкспонатRepos(AppDBContext appDB)
        {
            appDBContext = appDB;
        }
        public IEnumerable<Экспонат> Showpieces => appDBContext.Экспонат;
    }
}
