using KKKKPPP.Data.Interfaces;
using KKKKPPP.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KKKKPPP.Data.Repository
{
    public class СтильRepos : IСтиль
    {
        public readonly AppDBContext appDBContext;

        public СтильRepos(AppDBContext appDB)
        {
            appDBContext = appDB;
        }
        public IEnumerable<Стиль> Styles => appDBContext.Стиль;
    }
}
