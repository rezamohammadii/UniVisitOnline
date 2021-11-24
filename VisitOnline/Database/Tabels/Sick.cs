using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VisitOnline.Database.Tabels
{
    public class Sick
    {

        [Key]
        public int SickId { get; set; }
        public string NameFamily { get; set; }
        public string Mobile { get; set; }
        public string Password { get; set; }

        public string province { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public int Region { get; set; }
        public int Age { get; set; }

       
       


    }
}
