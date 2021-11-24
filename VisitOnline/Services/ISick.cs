using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisitOnline.Database.Tabels;

namespace VisitOnline.Services
{
    public interface ISick
    {
        
        Sick GetSick(string username);
    }
}
