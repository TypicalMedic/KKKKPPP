using KKKKPPP.Data.Interfaces;
using KKKKPPP.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KKKKPPP.Data.Repository
{
    public class ЖанрRepos : IЖанр
    {
        public readonly AppDBContext appDBContext;

        public ЖанрRepos(AppDBContext appDB)
        {
            appDBContext = appDB;
        }
        public IEnumerable<Жанр> Jenres => appDBContext.Жанр;
    }
}
