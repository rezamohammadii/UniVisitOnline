using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VisitOnline.Database;
using VisitOnline.Models;
using VisitOnline.Services;

namespace VisitOnline.Controllers
{
    public class AdminController : Controller
    {
        private IAdmin _admin;
        private IUser _user;
        private DatabaseContext context;
        public AdminController(DatabaseContext _context, IAdmin admin , IUser user)
        {
            context = _context;
            _admin = admin;
            _user = user;
        }
        // GET: Admin
        public IActionResult Home()
        {
            return View();
        }


        
        public IActionResult ListSicks()
        {
            List<SickviewModels> models = _admin.GetListSick();
            return View(models);
        }

        public IActionResult ListDoctors()
        {
            List<DoctorViewModel> models = _admin.GetDoctorsList();
            return View(models);
        }

        public bool ConfirmActive(int id)
        {
            if (id != 0 )
            {
                _admin.ActiveAccDoc(id);
            }

            else
            {
                return false;
            }
            return true;
        }


     
    }
}