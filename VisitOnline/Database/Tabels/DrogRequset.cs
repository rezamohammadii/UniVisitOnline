using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VisitOnline.Database.Tabels
{
    public class DrogRequset
    {
        [Key]
        public int Id { get; set; }
        public int DrogRequsetId { get; set; }
        public int VisitRequestId { get; set; }
        public string Description { get; set; }
        public string Date { get; set; }
        
       
    }
}
