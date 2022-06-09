using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KKKKPPP.Data.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsAdministrator { get; set; }
        [NotMapped]
        public List<int> LikedExpos { get; set; }
        [NotMapped]
        public List<int> LikedExcurs { get; set; }
    }
}
