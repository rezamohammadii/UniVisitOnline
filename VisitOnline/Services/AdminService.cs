using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using VisitOnline.Database;
using VisitOnline.Database.Tabels;
using VisitOnline.Models;

namespace VisitOnline.Services
{
    public class AdminService : IAdmin
    {
        private DatabaseContext context;
        private PersianCalendar pc = new PersianCalendar();
        public AdminService(DatabaseContext _context)
        {
            context = _context;
        }

        public void ActiveAccDoc(int id)
        {
            Doctor doctor = context.Doctors.Include(i=>i.User).Where(d => d.DoctorId == id).FirstOrDefault();
            doctor.User.Activate = "enable";
            context.SaveChanges();
        }

        public List<Tiket> AllListTikets()
        {
            List<Tiket> tikets = context.Tikets.ToList();
            return tikets;
        }

        public List<DoctorViewModel> GetDoctorsList()
        {
            List<DoctorViewModel> doctorViews = new List<DoctorViewModel>();
            doctorViews = context.Doctors.Include(x => x.User).Select(u => new DoctorViewModel { AddressMatab = u.AddressMatab, MeliCode = u.MeliCode, NameFamily = u.User.NameFamily, Mobile = u.User.Mobile, SNP = u.SNP, Takhasos = u.Takhasos, TelMatab = u.TelMatab , DoctorId = u.DoctorId }).ToList();

            return doctorViews;
        }

        public List<SickviewModels> GetListSick()
        {
            List<SickviewModels> sickviews = new List<SickviewModels>();
            sickviews = context.Sick.Include(i => i.User).Select(x => new SickviewModels { Address = x.Address, Age = x.Age, City = x.City, Mobile = x.User.Mobile, NameFamily = x.User.NameFamily, province = x.province  , Id = x.SickId}).ToList();

            return sickviews;
        }

        public void InsertTiket(TiketModel model)
        {
            Tiket tiket = new Tiket();
            tiket.AnswerBody = model.AnswerBody;
            tiket.Body = model.Body;
            tiket.IsRead = false;
            tiket.NumberTiket = int.Parse(model.NumberTiket);
            tiket.SendDate = pc.GetYear(DateTime.Now).ToString("0000") + "/" + pc.GetMonth(DateTime.Now).ToString("00") +
                             "/" + pc.GetDayOfMonth(DateTime.Now).ToString("00");
            tiket.Sender = model.Sender;
            tiket.Title = model.Title;

            context.Tikets.Add(tiket);
            context.SaveChanges();

        }

        public List<Tiket> ListTike(string username)
        {
            bool checkRecord = context.Tikets.Where(x => x.Sender == null).Any();
            List<Tiket> tiket = new List<Tiket>();
<<<<<<< HEAD
            if (!checkRecord)
=======
            if (checkRecord)
>>>>>>> ade96a1a290fe540836e263ffc08530db2a1f376
            {
                 tiket = context.Tikets.Where(u => u.Sender == username).ToList();
                
            }
           
            return tiket;

        }
    }
}
