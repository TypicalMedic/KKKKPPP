using KKKKPPP.Data.Interfaces;
using KKKKPPP.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KKKKPPP.Data.Repository
{
    public class СтранаRepos : IСтрана
    {
        public readonly AppDBContext appDBContext;

        public СтранаRepos(AppDBContext appDB)
        {
            appDBContext = appDB;
        }

        public IEnumerable<Страна> Countries => appDBContext.Страна;
    }
}
