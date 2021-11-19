using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VisitOnline.Database.Tabels
{
    public class Users
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public string NameFamily { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
        public int Region { get; set; }
        public int Age { get; set; }
        
        public virtual Role Role { get; set; }
    }
}
