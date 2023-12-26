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
            builder.HasIndex(q => q.Name).IsUnique();
            builder.HasMany(q => q.CategoryGalleries);
            builder.Property(q => q.Name).IsRequired().HasMaxLength(50);
            builder.Property(q => q.Description).IsRequired().HasMaxLength(100);
        }
    }
}
