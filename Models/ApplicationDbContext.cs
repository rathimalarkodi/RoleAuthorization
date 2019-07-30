using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authorization.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<DbContext> dbContextOptions) : base(dbContextOptions) { }
        public DbSet<Users> Users { get; set; }
        public DbSet<Roles> Roles {get;set;}
    }
}
