using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VisitOnline.Models
{
    public class RequestVisitModel
    {
        [Display(Name = "عنوان بیماری ")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        [MaxLength(100, ErrorMessage = "مقدار {0} نباید بیش تر از {1} کاراکتر باشد")]
        [MinLength(5, ErrorMessage = "مقدار {0} نباید کم تر از {1} کاراکتر باشد")]
        public string Title { get; set; }

        [Display(Name = "شماره نسخه ")]
    
        public string NumberNoskhe { get; set; }

        

        public string Status { get; set; }


        [Display(Name = "توضیحات ")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        [MaxLength(500, ErrorMessage = "مقدار {0} نباید بیش تر از {1} کاراکتر باشد")]
        [MinLength(5, ErrorMessage = "مقدار {0} نباید کم تر از {1} کاراکتر باشد")]

        public string Description { get; set; }

        [Display(Name = "نوع بیماری ")]
      
        public string SickType { get; set; }

        public string SelectDoctor { get; set; }
        public string MobileSick { get; set; }
        public string NameSick { get; set; }
        public string Date { get; set; }
        

    }
}
