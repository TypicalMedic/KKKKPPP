using KKKKPPP.Data.Interfaces;
using KKKKPPP.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KKKKPPP.Data.Repository
{
    public class ЭкскурсияRepos : IЭкскурсия
    {
        public readonly AppDBContext appDBContext;

        public ЭкскурсияRepos(AppDBContext appDB)
        {
            appDBContext = appDB;
        }
        public IEnumerable<Экскурсия> Excursions => appDBContext.Экскурсия;
    }
}
