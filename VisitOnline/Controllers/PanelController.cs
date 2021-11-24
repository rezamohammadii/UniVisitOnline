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
            Users users = user.GetUser(currentuser);
            
            return View(users);
        }

        public IActionResult CompleteInformation()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CompleteInformation(SickviewModels models)
        {

            return View(models);
        }
    }
}
