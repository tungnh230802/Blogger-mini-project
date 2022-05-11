using BlogDAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;

namespace BlogDAL.Extension
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole { Name = "member" },
                new IdentityRole { Name = "moderator"});


            var roleId = new Guid("8D04DCE2-969A-435D-BBA4-DF3F325983DC").ToString();
            var adminId = new Guid("69BD714F-9576-45BA-B5B7-F00649BE00DE").ToString();
            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = roleId,
                Name = "admin",
            });

            var hasher = new PasswordHasher<AppUser>();
            builder.Entity<AppUser>().HasData(new AppUser
            {
                Id = adminId,
                UserName = "admin",
                NormalizedUserName = "admin",
                Email = "tungnh230802@gmail.com",
                NormalizedEmail = "tungnh230802@gmail.com",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "123456"),
                SecurityStamp = string.Empty,
            });

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = roleId,
                UserId = adminId
            });
        }
    }
}
