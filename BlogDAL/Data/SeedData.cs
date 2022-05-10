using BlogDAL.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlogDAL.Data
{
    public class SeedData
    {
        public static async Task SeedUsers(UserManager<User> userManager,
           RoleManager<IdentityRole> roleManager)
        {
            var roles = new List<IdentityRole>
            {
                new IdentityRole{Name = "Member"},
                new IdentityRole{Name = "Admin"},
                new IdentityRole{Name = "Moderator"},
            };

            foreach (var role in roles)
            {
                await roleManager.CreateAsync(role);
            }

            
            var admin = new User
            {
                UserName = "admin"
            };

            await userManager.CreateAsync(admin, "12345678");
            await userManager.AddToRolesAsync(admin, new[] { "Admin"});
        }
    }
}

