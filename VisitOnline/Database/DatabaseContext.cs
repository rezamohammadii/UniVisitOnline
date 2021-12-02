using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisitOnline.Database.Tabels;

namespace VisitOnline.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
        public DbSet<Users> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Sick> Sick { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<VisitRequest> VisitRequests { get; set; }
        public DbSet<DrogStore> DrogStores { get; set; }
        public DbSet<DrogRequset> DrogRequsets { get; set; }
        public DbSet<Takhasos> Takhasos { get; set; }
       

    }
}
