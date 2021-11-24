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

        [Key,ForeignKey("User")]
        public int UserId { get; set; }
        public string province { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public int Region { get; set; }
        public int Age { get; set; }

       
        public virtual Users User { get; set; }


    }
}
