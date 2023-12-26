using Microsoft.EntityFrameworkCore;
using PunchcodeStudios.Domain;
using PunchcodeStudios.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace PunchcodeStudios.Persistence.DatabaseContext
{
    public class PCStudioDbContext : DbContext
    {
        public PCStudioDbContext(DbContextOptions<PCStudioDbContext> options) : base(options)
        {
            
        }

        public DbSet<Gallery> Galleries { get; set; }
        public DbSet<GalleryType> GalleryTypes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryGallery> CategoryGalleries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // use configurations to seed database
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PCStudioDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach(var entry in base.ChangeTracker.Entries<BaseEntity>()
                .Where(q => q.State == EntityState.Added || q.State == EntityState.Modified || q.State == EntityState.Deleted))
            {
                entry.Entity.DateUpdated = DateTime.Now;

                if(entry.State == EntityState.Added)
                {
                    entry.Entity.DateCreated = DateTime.Now;
                }

                if(entry.State == EntityState.Deleted)
                {
                    entry.Entity.DateDeleted = DateTime.Now;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
