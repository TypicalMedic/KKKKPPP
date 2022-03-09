using KKKKPPP.Data.Interfaces;
using KKKKPPP.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KKKKPPP.Data.Repository
{
    public class СостояниеRepos : IСостояние
    {
        public readonly AppDBContext appDBContext;

        public СостояниеRepos(AppDBContext appDB)
        {
            appDBContext = appDB;
        }

        public IEnumerable<Состояние_картины> Conditions => appDBContext.Состояние_картины;
    }
}
