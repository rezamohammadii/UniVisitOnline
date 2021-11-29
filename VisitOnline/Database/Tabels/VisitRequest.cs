using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VisitOnline.Database.Tabels
{
    public class VisitRequest
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public int NumberNoskhe { get; set; }
        public string Status { get; set; }
        public DateTime Date { get; set; }

        public virtual ICollection<Doctor> Doctors { get; set; }
        public virtual ICollection<Sick> Sick { get; set; }
    }
}
