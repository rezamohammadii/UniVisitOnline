using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VisitOnline.Models
{
    public class RegisterModels
    {
        
        public string Mobile { get; set; }

       
        public string Password { get; set; }

        
       // public string ConfirmPassword { get; set; }

        public string NameFamily { get; set; }
        public int Whois { get; set; }

    }
}
