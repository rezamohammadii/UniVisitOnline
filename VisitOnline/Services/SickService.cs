using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VisitOnline.Database;
using VisitOnline.Database.Tabels;
namespace VisitOnline.Services
{
    public class SickService : ISick
    {
        private DatabaseContext context;
        public SickService(DatabaseContext _context)
        {
            context = _context;
        }

        public Sick GetSick(string username)
        {
            return context.Sicks.Where(x => x.Mobile == username).FirstOrDefault();
        }

       
    }
}
