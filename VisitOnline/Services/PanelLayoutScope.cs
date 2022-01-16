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

        public string GetUserNameFamily(string username)
        {
            return _user.GetUserNameFamily(username);
        }
        public string RandomCodeNoskhe()
        {
            Random random = new Random();
            return random.Next(1000, 9999).ToString();
            
        }

        public string StatusActivate(string username)
        {
            return _user.GetUserStatus(username);
        }
    }
}
