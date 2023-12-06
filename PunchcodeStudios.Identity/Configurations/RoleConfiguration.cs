using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PunchcodeStudios.Identity.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Id = "a45b2d37-afe3-471c-8496-36c1ab65f58f",
                    Name = "Anonymous",
                    NormalizedName = "ANONYMOUS"
                },
                new IdentityRole
                {
                    Id = "8eae84d4-f165-44d5-9285-64ab6da1b7de",
                    Name = "System_Admin",
                    NormalizedName = "SYSTEM_ADMIN"
                }
            );
        }
    }
}
