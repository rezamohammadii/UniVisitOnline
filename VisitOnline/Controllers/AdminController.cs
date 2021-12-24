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
        private DatabaseContext context;
        public AdminController(DatabaseContext _context, IAdmin admin)
        {
            context = _context;
            _admin = admin;
        }
        // GET: Admin
        public IActionResult Home()
        {
            return View();
        }


        
        public ActionResult ListSicks()
        {
            List<SickviewModels> models = _admin.GetListSick();
            return View(models);
        }

     
    }
}