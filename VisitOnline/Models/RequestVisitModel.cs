using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VisitOnline.Models
{
    public class RequestVisitModel
    {
        
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        [MaxLength(100, ErrorMessage = "مقدار {0} نباید بیش تر از {1} کاراکتر باشد")]
        [MinLength(5, ErrorMessage = "مقدار {0} نباید کم تر از {1} کاراکتر باشد")]
        public string Title { get; set; }

        [Display(Name = "شماره نسخه ")]
    
        public string NumberNoskhe { get; set; }

        

        public string Status { get; set; }


        
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        [MaxLength(500, ErrorMessage = "مقدار {0} نباید بیش تر از {1} کاراکتر باشد")]
        [MinLength(5, ErrorMessage = "مقدار {0} نباید کم تر از {1} کاراکتر باشد")]

        public string Description { get; set; }

        
      
        public string SickType { get; set; }

        public string SelectDoctor { get; set; }
        public string MobileSick { get; set; }
        public string NameSick { get; set; }
        public string DateRequest { get; set; }
        public string DateAnswer { get; set; }
        public string AnswerDoctor { get; set; }
        public F PicNoskhe { get; set; }


    }
}
