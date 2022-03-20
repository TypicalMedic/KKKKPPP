using KKKKPPP.Data.Interfaces;
using KKKKPPP.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KKKKPPP.Data.Repository
{
    public class Аналитический_отчетRepos : IАналитический_отчет
    {
        public readonly AppDBContext appDBContext;

        public Аналитический_отчетRepos(AppDBContext appDB)
        {
            appDBContext = appDB;
        }
        public IEnumerable<Аналитический_отчет> AnalyticalReports => appDBContext.Аналитический_отчет;

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }
    }
}
