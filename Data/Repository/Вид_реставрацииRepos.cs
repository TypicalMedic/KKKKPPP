using KKKKPPP.Data.Interfaces;
using KKKKPPP.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KKKKPPP.Data.Repository
{
    public class Вид_реставрацииRepos : IВид_реставрации
    {
        public readonly AppDBContext appDBContext;

        public Вид_реставрацииRepos(AppDBContext appDB)
        {
            appDBContext = appDB;
        }
        public IEnumerable<Вид_реставрации> Restoration_types => appDBContext.Вид_реставрации;
    }
}
