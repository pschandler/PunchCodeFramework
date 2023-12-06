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
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "8eae84d4-f165-44d5-9285-64ab6da1b7de",
                    UserId = "d23dce97-3bda-431f-b1e5-0233e847bbf8"
                }
            );
        }
    }
}
