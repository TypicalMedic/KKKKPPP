using KKKKPPP.Data.Interfaces;
using KKKKPPP.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KKKKPPP.Data.Repository
{
    public class АвторRepos : IАвтор
    {
        public readonly AppDBContext appDBContext;

        public АвторRepos(AppDBContext appDB)
        {
            appDBContext = appDB;
        }

        public IEnumerable<Автор> Authors => appDBContext.Автор;

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }
    }
}
