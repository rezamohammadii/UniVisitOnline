using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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

        public List<DoctorViewModel> GetDoctorsList()
        {
            List<DoctorViewModel> doctorViews = new List<DoctorViewModel>();
            doctorViews = context.Doctors.Include(x => x.User).Select(u => new DoctorViewModel { AddressMatab = u.AddressMatab, MeliCode = u.MeliCode, NameFamily = u.User.NameFamily, Mobile = u.User.Mobile, SNP = u.SNP, Takhasos = u.Takhasos, TelMatab = u.TelMatab , DoctorId = u.DoctorId }).ToList();

            return doctorViews;
        }

        public List<SickviewModels> GetListSick()
        {
            List<SickviewModels> sickviews = new List<SickviewModels>();
            sickviews = context.Sick.Include(i => i.User).Select(x => new SickviewModels { Address = x.Address, Age = x.Age, City = x.City, Mobile = x.User.Mobile, NameFamily = x.User.NameFamily, province = x.province }).ToList();

            return sickviews;
        }
    }
}
