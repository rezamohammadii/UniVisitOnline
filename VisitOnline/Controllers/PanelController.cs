using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisitOnline.Database.Tabels;
using VisitOnline.Models;
using VisitOnline.Services;

namespace VisitOnline.Controllers
{
    public class PanelController : Controller
    {
        private IUser user;
        public PanelController(IUser _user)
        {
            user = _user;
        }

        public IActionResult DocDashboard()
        {
            string currentuser = User.Identity.Name;
            Doctor users = user.GetDoctor(currentuser);
            DoctorViewModel doctor = new DoctorViewModel()
            {
                Mobile = users.User.Mobile,
                AddressMatab = users.AddressMatab,
                Description = users.Description,
                MeliCode = users.MeliCode,
                NameFamily = users.User.NameFamily,
                province = users.province,
                Rate = users.Rate,
                SNP = users.SNP,
                Takhasos = users.Takhasos,
                TelMatab = users.TelMatab
            };

            
            return View(doctor);
        }

        public IActionResult CompleteInformation()
        {
            string currentuser = User.Identity.Name;
            Doctor users = user.GetDoctor(currentuser);
            DoctorViewModel doctor = new DoctorViewModel()
            {
                Mobile = users.User.Mobile,
                AddressMatab = users.AddressMatab,
                Description = users.Description,
                MeliCode = users.MeliCode,
                NameFamily = users.User.NameFamily,
                province = users.province,
                Rate = users.Rate,
                SNP = users.SNP,
                Takhasos = users.Takhasos,
                TelMatab = users.TelMatab
            };
            return View(doctor);
        }
        [HttpPost]
        public IActionResult CompleteInformation(DoctorViewModel models)
        {
            if (ModelState.IsValid)
            {
                user.UpdateDoctor(models);

            }
            return View(models);
        }
    }
}
