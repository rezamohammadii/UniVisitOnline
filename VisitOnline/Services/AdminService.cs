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

        public List<DoctorViewModel> GetDoctorsList()
        {
            List<DoctorViewModel> doctorViews = new List<DoctorViewModel>();
            List<Doctor> doctors = new List<Doctor>();
            doctors = context.Doctors.ToList();
            List<Users> users = context.Users.Where(x => x.RoleId == 3).ToList();
            DoctorViewModel model = new DoctorViewModel();
            foreach (var item in doctors)
            {
                model.AddressMatab = item.AddressMatab;
                model.MeliCode = item.MeliCode;
                model.SNP = item.SNP;
                model.Takhasos = item.Takhasos;
                model.TelMatab = item.TelMatab;
                foreach (var item2 in users)
                {
                    model.NameFamily = item2.NameFamily;
                    model.Mobile = item2.Mobile;

                }
                doctorViews.Add(model);
            }
            return doctorViews;
        }

        public List<SickviewModels> GetListSick()
        {
            List<SickviewModels> sickviews = new List<SickviewModels>();
            List<Sick> sicks = new List<Sick>();
            sicks = context.Sick.ToList();
            List<Users> SikcUser = context.Users.Where(x => x.RoleId == 2).ToList();
            SickviewModels models = new SickviewModels();

                foreach (var item2 in sicks)
                {
                models.Address = item2.Address;
                models.Age = item2.Age;
                models.City = item2.City;
                models.province = item2.province;
                    foreach (var item3 in SikcUser)
                    {
                    models.NameFamily = item3.NameFamily;
                    models.Mobile = item3.Mobile;
                    }
                 sickviews.Add(models);
                }

            return sickviews;
        }
    }
}
