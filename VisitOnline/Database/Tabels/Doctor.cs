using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VisitOnline.Database.Tabels
{
    public class Doctor
    {
        [Key]
        
        [ForeignKey("Users")]
        public int UserId { get; set; }
        public string NameFamily { get; set; }
        public string AddressMatab { get; set; }
        public string Takhasos { get; set; }
        public string TelMatab { get; set; }
        public string province { get; set; }
        public string Description { get; set; }
        public long MeliCode { get; set; }
        public int Rate { get; set; }
        public long SNP { get; set; }

        public virtual Users Users { get; set; }
    }
}
