using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace VisitOnline.Models
{
    public class DoctorViewModel
    {
        [Display(Name = "نام و نام خانوادگی ")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        [MaxLength(50, ErrorMessage = "مقدار {0} نباید بیش تر از {1} کاراکتر باشد")]
        [MinLength(5, ErrorMessage = "مقدار {0} نباید کم تر از {1} کاراکتر باشد")]        
        public string NameFamily { get; set; }

        [Display(Name = "شماره موبایل")]
        
        [MaxLength(11, ErrorMessage = "مقدار {0} نباید بیش تر از {1} کاراکتر باشد")]
        [MinLength(11, ErrorMessage = "مقدار {0} نباید کم تر از {1} کاراکتر باشد")]
        [Phone(ErrorMessage = "فقط عدد می توانید وارد کنید")]
        public string Mobile { get; set; }

        [Display(Name = "آدرس مطب")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        [MaxLength(250, ErrorMessage = "مقدار {0} نباید بیش تر از {1} کاراکتر باشد")]
        [MinLength(5, ErrorMessage = "مقدار {0} نباید کم تر از {1} کاراکتر باشد")]     
        public string AddressMatab { get; set; }

        [Display(Name = "تخصص")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string Takhasos { get; set; }

        [Display(Name = "تلفن مطب")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        [MaxLength(11, ErrorMessage = "مقدار {0} نباید بیش تر از {1} کاراکتر باشد")]
        [MinLength(5, ErrorMessage = "مقدار {0} نباید کم تر از {1} کاراکتر باشد")]
        [Phone(ErrorMessage = "فقط عدد می توانید وارد کنید")]
        public string TelMatab { get; set; }

        public int DoctorId { get; set; }
        public string Description { get; set; }
        public string Certificate { get; set; }
        public string Activate { get; set; }

        [Display(Name = "کد ملی")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        [MaxLength(10, ErrorMessage = "مقدار {0} نباید بیش تر از {1} کاراکتر باشد")]
        [MinLength(10, ErrorMessage = "مقدار {0} نباید کم تر از {1} کاراکتر باشد")]
        [Phone(ErrorMessage = "فقط عدد می توانید وارد کنید")]
        public string MeliCode { get; set; }
        public int Rate { get; set; }

        [Display(Name = "شماره نظام پزشکی")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        [MaxLength(7, ErrorMessage = "مقدار {0} نباید بیش تر از {1} کاراکتر باشد")]
        [MinLength(7, ErrorMessage = "مقدار {0} نباید کم تر از {1} کاراکتر باشد")]
        [Phone(ErrorMessage = "فقط عدد می توانید وارد کنید")]
        public string SNP { get; set; }
    }
}
