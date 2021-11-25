using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VisitOnline.Database.Tabels
{
    public class Users
    {
        [Key]
        public int Id { get; set; }
        public int RoleId { get; set; }
        public string NameFamily { get; set; }
        public string Mobile { get; set; }       
        public string Password { get; set; }
        public string Activate { get; set; }
        public virtual Role Role { get; set; }

        public virtual ICollection<Doctor> Doctor { get; set; }
        public virtual ICollection<Sick> Sicks { get; set; }

        //public virtual Doctor Doctors { get; set; }
        //public virtual Sick Sicks { get; set; }


    }
}
