﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PunchcodeStudios.Domain;

namespace PunchcodeStudios.Persistence.Configurations
{
    public class CategoryConfigurations : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasIndex(q => q.Name).IsUnique();
            builder.HasMany(q => q.CategoryGalleries);
            builder.Property(q => q.Name).IsRequired().HasMaxLength(50);
            builder.Property(q => q.Description).IsRequired().HasMaxLength(100);
        }
    }
}
