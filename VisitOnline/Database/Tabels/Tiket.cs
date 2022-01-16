using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VisitOnline.Database.Tabels
{
    public class Tiket
    {
        [Key]
        public int Id { get; set; }
        public int NumberTiket { get; set; }
        public string Title { get; set; }
        public string Sender { get; set; }
        public string Body { get; set; }
        public string SendDate { get; set; }
        public string AnswerDate { get; set; }
        public string AnswerBody { get; set; }
        public bool IsRead { get; set; }
        
    }
}
