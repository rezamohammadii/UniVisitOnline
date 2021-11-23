using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VisitOnline.Models
{
    public class DoctorViewModel
    {
        public string NameFamily { get; set; }
        public string Mobile { get; set; }
        public string AddressMatab { get; set; }
        public string Takhasos { get; set; }
        public string TelMatab { get; set; }
        public string province { get; set; }
        public string Description { get; set; }
        public long MeliCode { get; set; }
        public int Rate { get; set; }
        public long SNP { get; set; }
    }
}
