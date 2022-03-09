using KKKKPPP.Data.Interfaces;
using KKKKPPP.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KKKKPPP.Data.Repository
{
    public class ЗалRepos : IЗал
    {
        public readonly AppDBContext appDBContext;

        public ЗалRepos(AppDBContext appDB)
        {
            appDBContext = appDB;
        }
        public IEnumerable<Зал> Rooms => appDBContext.Зал;
    }
}
