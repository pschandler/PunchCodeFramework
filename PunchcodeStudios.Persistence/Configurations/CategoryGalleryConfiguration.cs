using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PunchcodeStudios.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PunchcodeStudios.Persistence.Configurations
{
    public class CategoryGalleryConfiguration : IEntityTypeConfiguration<CategoryGallery>
    {
        public void Configure(EntityTypeBuilder<CategoryGallery> builder)
        {
            builder.ToTable("CategoryGalleries");
            builder.HasKey(c => c.Id);
            builder.HasOne(q => q.Gallery)
                .WithMany(q => q.CategoryGalleries)
                .HasForeignKey(q => q.GalleriesId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(q => q.Category)
                .WithMany(q => q.CategoryGalleries)
                .HasForeignKey(q => q.CategoriesId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
