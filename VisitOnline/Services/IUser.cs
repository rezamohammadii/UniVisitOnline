using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisitOnline.Database.Tabels;

namespace VisitOnline.Services
{
    public interface IUser
    {
        int GetMaxRole();

        string GetUserRoleName(string username);
        Users GetUser(string username);
    }
}
