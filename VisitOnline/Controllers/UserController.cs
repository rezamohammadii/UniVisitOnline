using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisitOnline.Models;
using VisitOnline.Database;
using VisitOnline.Database.Tabels;
using Microsoft.EntityFrameworkCore;
using VisitOnline.Services;

namespace VisitOnline.Controllers
{
    public class UserController : Controller
    {
        private IUser _users;
        private DatabaseContext context;
        public UserController(DatabaseContext _context , IUser users)
        {
            context = _context;
            _users = users;
        }
        // GET: UserController
        public IActionResult Login()
        {
            return View();
        }


        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginModels models)
        {
            if (ModelState.IsValid)
            {
                string hashpassword = CodeFactor.HashGenerator(models.Password);
                var checkExist = context.Users.Include(x=>x.Role).FirstOrDefault(x => x.Mobile == models.Mobile && x.Password == hashpassword);

                if (checkExist == null)
                {
                    ModelState.AddModelError("Mobile", "شماره موبایل وارد شده موجود نمی باشد! ثبت نام کنید ");
                    
                }
                else
                {
                    switch (checkExist.Role.Name)
                    {
                        case "doctor":
                           return RedirectToAction("DocDashboard", "Panel");
                        case "sick":
                            return RedirectToAction("SickDashboard", "Panel");
                        case "drogStore":
                            return RedirectToAction("DrogStorDashboard", "Panel");
                            
                    }
                }
            }
            return View(models);
        }

        // GET: UserController/Edit/5
        public IActionResult Register()
        {
            return View();
        }

        // POST: UserController/Edit/5
        [HttpPost]
        
        public IActionResult Register(RegisterModels models)
        {
            if (ModelState.IsValid)
            {
                var CheckExist = context.Users.Where(x => x.Mobile == models.Mobile).FirstOrDefault();
                if (CheckExist != null)
                {
                    return RedirectToAction(nameof(Login));
                }
                else
                {
                    string hashPasword = CodeFactor.HashGenerator(models.Password);
                    Users users = new Users();

                    users.NameFamily = models.NameFamily;
                    users.Password = hashPasword;
                    if (models.Whois == 0)
                    {
                        users.RoleId = 3;
                    }
                    users.RoleId = models.Whois;
                    users.Mobile = models.Mobile;

                    context.Users.Add(users);
                    context.SaveChanges();
                }
            }
            return View(models);
        }
      
    }
}
