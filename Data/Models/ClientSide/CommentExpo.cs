using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KKKKPPP.Data.Models.ClientSide
{
    [Keyless]
    public class CommentExpo
    {
        public int ExpoId { get; set; }
        public int UserId { get; set; }
        public string Comment { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
