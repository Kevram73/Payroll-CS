using Microsoft.AspNetCore.Identity;
using Payroll.Models;
using System.Threading.Tasks;

namespace Payroll.Data
{
    public static class SeedData
    {
        public static async Task SeedAdminUserAsync(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            // Check if Admin role exists
            if (!await roleManager.RoleExistsAsync("Admin"))
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
            }

            // Check if Admin user exists
            if (await userManager.FindByEmailAsync("admin@payroll.com") == null)
            {
                var admin = new AppUser
                {
                    UserName = "admin@payroll.com",
                    Email = "admin@payroll.com",
                    FirstName = "Admin",
                    LastName = "User",
                    EmailConfirmed = true
                };

                // Create admin user
                var result = await userManager.CreateAsync(admin, "Admin@123");

                // Assign Admin role
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "Admin");
                }
            }
        }
    }
}
