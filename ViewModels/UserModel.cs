using KKKKPPP.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KKKKPPP.ViewModels
{
    public static class UserViewModel
    {
        public static User userInfo { get; set; } = null;
        public static string userType { get; set; } = "None";
        public static List<int> ExpoHistory { get; set; } = new List<int>();
    }
}
