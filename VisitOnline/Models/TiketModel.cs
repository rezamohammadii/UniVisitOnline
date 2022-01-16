using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VisitOnline.Models
{
    public class TiketModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Sender { get; set; }
        public string Body { get; set; }
        public string SendDate { get; set; }
        public string AnswerDate { get; set; }
        public bool IsRead { get; set; }

    }
}
