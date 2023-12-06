using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PunchcodeStudios.Identity.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PunchcodeStudios.Identity.DbContext
{
    public class PCIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public PCIdentityDbContext(DbContextOptions<PCIdentityDbContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(PCIdentityDbContext).Assembly);
        }
    }
}
