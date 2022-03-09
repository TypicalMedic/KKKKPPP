using KKKKPPP.Data.Interfaces;
using KKKKPPP.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Reflection;

namespace KKKKPPP.Data.Repository
{
    public class СущностьRepos : IСущности
    {
        public readonly AppDBContext appDBContext;

        public СущностьRepos(AppDBContext appDB)
        {
            appDBContext = appDB;
        }

        public IEnumerable<string> Entities => from t in Assembly.GetExecutingAssembly().GetTypes() where t.IsClass && t.Namespace == "KKKKPPP.Data.Models" select t.Name.ToString();

        public IEnumerable<Type> EntityTypes =>from t in Assembly.GetExecutingAssembly().GetTypes() where t.IsClass && t.Namespace == "KKKKPPP.Data.Models" select t;
    }
}
