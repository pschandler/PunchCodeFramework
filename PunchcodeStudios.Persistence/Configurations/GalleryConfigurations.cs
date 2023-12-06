using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PunchcodeStudios.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace PunchcodeStudios.Persistence.Configurations
{
    public class GalleryConfigurations : IEntityTypeConfiguration<Gallery>
    {
        public void Configure(EntityTypeBuilder<Gallery> builder)
        {
            // seed data
            //builder.HasData(
            //    new Gallery
            //    {
            //        Id = Guid.NewGuid(),
            //        Name = "Example Gallery",
            //        Description = "Example Gallery Description",
            //        DateCreated = DateTime.Now,
            //        DateUpdated = DateTime.Now,
            //    }
            //);

            builder.Property(q => q.Name).IsRequired().HasMaxLength(100);
            builder.Property(q => q.Description).IsRequired().HasMaxLength(150);
        }
    }
}
