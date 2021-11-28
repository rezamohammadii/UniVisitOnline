using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VisitOnline.Models
{
    public class RequestVisitModel
    {
        public string Title { get; set; }
        public int NumberNoskhe { get; set; }
        public string Status { get; set; }
        public string SickType { get; set; }
        public string SelectDoctor { get; set; }
        public string Price { get; set; }
    }
}
