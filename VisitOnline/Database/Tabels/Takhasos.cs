using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VisitOnline.Database.Tabels
{
    public class Takhasos
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
