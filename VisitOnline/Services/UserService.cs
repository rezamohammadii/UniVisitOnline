using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VisitOnline.Database;
using VisitOnline.Database.Tabels;
namespace VisitOnline.Services
{
    public class UserService : IUser
    {
        private DatabaseContext context;
        public UserService(DatabaseContext _context)
        {
            context = _context;
        }

        public int GetMaxRole()
        {
            return context.Roles.Max(i => i.Id);
        }

        public Users GetUser(string username)
        {
            return context.Users.Where(x => x.Mobile == username).FirstOrDefault();
        }

        public string GetUserRoleName(string username)
        {
            return context.Users.Include(u => u.Role).FirstOrDefault(u => u.Mobile == username).Role.Name;
        }
    }
}
