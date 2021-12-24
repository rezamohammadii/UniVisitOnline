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

        public List<SickviewModels> GetListSick()
        {
            List<SickviewModels> sickviews = new List<SickviewModels>();
            List<Sick> sicks = new List<Sick>();
            sicks = context.Sick.ToList();
            List<Users> SikcUser = context.Users.Where(x => x.RoleId == 2).ToList();
            foreach (var item in sickviews)
            {
               
                foreach (var item2 in sicks)
                {
                    item.Address = item2.Address;
                    item.Age = item2.Age;
                    item.City = item2.City;
                    item.province = item2.province;
                    foreach (var item3 in SikcUser)
                    {
                        item.NameFamily = item3.NameFamily;
                        item.Mobile = item3.Mobile;
                    }
                }

            }
            return sickviews;
        }
    }
}
