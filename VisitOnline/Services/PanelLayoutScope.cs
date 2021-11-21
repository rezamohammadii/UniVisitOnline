using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VisitOnline.Services
{
    public class PanelLayoutScope
    {
        private IUser _user;
        public PanelLayoutScope(IUser user)
        {
            _user = user;
        }

        public string GetUserRoleName(string username)
        {
            return _user.GetUserRoleName(username);
        }
    }
}
