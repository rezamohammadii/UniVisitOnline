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
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

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
                var user = context.Users.Include(x=>x.Role).FirstOrDefault(x => x.Mobile == models.Mobile && x.Password == hashpassword);

                if (user == null)
                {
                    ModelState.AddModelError("Mobile", "شماره موبایل وارد شده موجود نمی باشد! ثبت نام کنید ");

                }
                else
                {
                    if (user.Role.Name == "پزشک")
                    {
                        var claim = new List<Claim>()
                            {
                                new Claim(ClaimTypes.NameIdentifier , user.Id.ToString()),
                                new Claim(ClaimTypes.Name , user.Mobile)
                            };
                        var identity = new ClaimsIdentity(claim, CookieAuthenticationDefaults.AuthenticationScheme);
                        var principal = new ClaimsPrincipal(identity);
                        var properties = new AuthenticationProperties()
                        {
                            IsPersistent = true
                        };
                        HttpContext.SignInAsync(principal, properties);
                        return RedirectToAction("DocDashboard", "Panel");
                    }
                    else if (user.Role.Name == "بیمار")
                    {
                        var claim = new List<Claim>()
                            {
                                new Claim(ClaimTypes.NameIdentifier , user.Id.ToString()),
                                new Claim(ClaimTypes.Name , user.Mobile)
                            };
                        var identity = new ClaimsIdentity(claim, CookieAuthenticationDefaults.AuthenticationScheme);
                        var principal = new ClaimsPrincipal(identity);
                        var properties = new AuthenticationProperties()
                        {
                            IsPersistent = true
                        };
                        HttpContext.SignInAsync(principal, properties);
                        return RedirectToAction("SickDashboard", "Panel");
                    }
                    else if (user.Role.Name == "داروخانه")
                    {
                        var claim = new List<Claim>()
                            {
                                new Claim(ClaimTypes.NameIdentifier , user.Id.ToString()),
                                new Claim(ClaimTypes.Name , user.Mobile)
                            };
                        var identity = new ClaimsIdentity(claim, CookieAuthenticationDefaults.AuthenticationScheme);
                        var principal = new ClaimsPrincipal(identity);
                        var properties = new AuthenticationProperties()
                        {
                            IsPersistent = true
                        };
                        HttpContext.SignInAsync(principal, properties);
                        return RedirectToAction("DrogStorDashboard", "Panel");
                    }
                    else
                    {
                        var claim = new List<Claim>()
                            {
                                new Claim(ClaimTypes.NameIdentifier , user.Id.ToString()),
                                new Claim(ClaimTypes.Name , user.Mobile)
                            };
                        var identity = new ClaimsIdentity(claim, CookieAuthenticationDefaults.AuthenticationScheme);
                        var principal = new ClaimsPrincipal(identity);
                        var properties = new AuthenticationProperties()
                        {
                            IsPersistent = true
                        };
                        HttpContext.SignInAsync(principal, properties);
                        return RedirectToAction("AdminDashboard", "Panel");
                    }
                       
                }
            }
            return View(models);
        }

        // GET: UserController/Edit/5
        public IActionResult Register()
        {
            ViewBag.OkRegister = false;
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
                        users.RoleId = 2;

                    }
                    users.RoleId = models.Whois;
                    users.Mobile = models.Mobile;
                    users.Activate = "disable";
                    context.Users.Add(users);
                    context.SaveChanges();

                    if (models.Whois == 2)
                    {
                        Sick sick = new Sick()
                        {
                            Address = null,
                            Age = 0,
                            City = null,
                            province = null,
                            Region = 0,
                            UserId = users.Id

                        };
                        context.Sick.Add(sick);
                        context.SaveChanges();
                    }

                    else if (models.Whois == 3)
                    {
                        Doctor doctor = new Doctor()
                        {
                            AddressMatab = null,
                            Description = null,
                            MeliCode = null,
                            province = null,
                            Rate = 0,
                            SNP = null,
                            Takhasos = null,
                            TelMatab = null,
                            UserId = users.Id

                        };
                        context.Doctors.Add(doctor);
                        context.SaveChanges();
                    }


                    
                    ViewBag.OkRegister = true;
                  //  return RedirectToAction(nameof(Login));
                }
            }
            return View(models);
        }
      
    }
}
