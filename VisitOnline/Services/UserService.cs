using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VisitOnline.Database;
using VisitOnline.Database.Tabels;
using VisitOnline.Models;

namespace VisitOnline.Services
{
    public class UserService : IUser
    {
        private DatabaseContext context;
        public UserService(DatabaseContext _context)
        {
            context = _context;
        }

        public Doctor GetDoctor(string username)
        {
            return context.Doctors.Include(x => x.User).FirstOrDefault(u => u.User.Mobile == username);
        }

        public int GetMaxRole()
        {
            return context.Roles.Max(i => i.Id);
        }


        public string GetUserRoleName(string username)
        {
            return context.Users.Include(u => u.Role).FirstOrDefault(u => u.Mobile == username).Role.Name;
        }

        public string GetUserStatus(string username)
        {
            return context.Users.FirstOrDefault(x => x.Mobile == username).Activate;
        }

        public void UpdateDoctor(DoctorViewModel models)
        {

            Doctor doctor = GetDoctor(models.Mobile);
            doctor.AddressMatab = models.AddressMatab;
            doctor.Description = models.Description;
            doctor.MeliCode = models.MeliCode;
            doctor.province = models.province;
            doctor.Rate = doctor.Rate;
            doctor.SNP = models.SNP;
            doctor.Takhasos = models.Takhasos;
            doctor.TelMatab = models.TelMatab;
            doctor.User.NameFamily = models.NameFamily;
            doctor.User.Activate = "waiting";
            context.SaveChanges();
        }
    }
}
