using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PunchcodeStudios.Identity.Models.Identity;

namespace PunchcodeStudios.Identity.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public UserConfiguration() { }

        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            builder.HasData(
                new ApplicationUser
                {
                    Id = "d23dce97-3bda-431f-b1e5-0233e847bbf8",
                    Email = "system@punchcodestudios.com",
                    NormalizedEmail = "SYSTEM@PUNCHCODESTUDIOS.COM",
                    FirstName = "System",
                    UserName = "system@punchcodestudios.com",
                    NormalizedUserName = "SYSTEM@PUNCHCODESTUDIOS.COM",
                    PasswordHash = hasher.HashPassword(null, "Dragon8473"),
                    EmailConfirmed = true
                },
                new ApplicationUser
                {
                    Id = "b725e066-299a-4a6b-94b4-8a47314ca053",
                    Email = "noreply@punchcodestudios.com",
                    NormalizedEmail = "NOREPLY@PUNCHCODESTUDIOS.COM",
                    FirstName = "NoReply",
                    UserName = "noreply@punchcodestudios.com",
                    NormalizedUserName = "NOREPLY@PUNCHCODESTUDIOS.COM",
                    PasswordHash = hasher.HashPassword(null, "Dragon8473"),
                    EmailConfirmed = true
                }
            );
        }
    }
}
