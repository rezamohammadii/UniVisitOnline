using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VisitOnline.Database;
using VisitOnline.Database.Tabels;
using VisitOnline.Models;
using VisitOnline.Services;

namespace VisitOnline.Controllers
{
    public class AdminController : Controller
    {
        private IAdmin _admin;
        private IUser _user;
        private DatabaseContext context;
        private PersianCalendar pc = new PersianCalendar();
        public AdminController(DatabaseContext _context, IAdmin admin , IUser user)
        {
            context = _context;
            _admin = admin;
            _user = user;
        }
        // GET: Admin
        public IActionResult Home()
        {
            CountDetail model = new CountDetail();
            model.CountDoctor = context.Doctors.Count();
            model.CountSick = context.Sick.Count();
            model.CountTiket = context.Tikets.Count();
            return View(model);
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


        public IActionResult Tiket()
        {
            string user = User.Identity.Name;
            List<Tiket> tt = _admin.ListTike(user);
           
            
            return View(tt);
        }

        public IActionResult AllListTiket()
        {
            List<Tiket> model = _admin.AllListTikets();
            return View(model);
        }

        public bool AnswerTiket(TiketModel model)
        {
            if (model.AnswerBody != null)
            {
                Tiket gettik = context.Tikets.Where(x => x.NumberTiket == int.Parse(model.NumberTiket)).FirstOrDefault();
                gettik.IsRead = true;
                gettik.AnswerDate = pc.GetYear(DateTime.Now).ToString("0000") + "/" + pc.GetMonth(DateTime.Now).ToString("00") +
                                 "/" + pc.GetDayOfMonth(DateTime.Now).ToString("00") + "  " + pc.GetHour(DateTime.Now).ToString("00") + ":" + pc.GetMinute(DateTime.Now).ToString("00");
                gettik.AnswerBody = model.AnswerBody;
                context.SaveChanges();
                return true;
            }
            return false;
            
        }

        public bool AddTiket(TiketModel model)
        {
            if (ModelState.IsValid)
            {
                model.Sender = User.Identity.Name;
                _admin.InsertTiket(model);
                return true;
            }
            else
            {
                return false;
            }
            
        }

<<<<<<< HEAD
        public bool DeleteSick(int id)
        {
            if (id != 0)
            {
                Sick sick = context.Sick.Where(x => x.SickId == id).FirstOrDefault();
                context.Sick.Remove(sick);
                context.SaveChanges();
                return true;
            }

            else
            {
                return false;
            }
           
        }
=======
     
>>>>>>> ade96a1a290fe540836e263ffc08530db2a1f376
    }
}