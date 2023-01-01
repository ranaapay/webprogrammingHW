using floristWebApi.Entities;
using Microsoft.AspNetCore.Identity;

namespace floristWebApi
{
    public class IdentityInitializer
    {
        public static void CreateAdmin(UserManager<User>? userManager, RoleManager<IdentityRole>? roleManager)
        {
            var admin = new User { Name = "Admin", SurName = "AdminUser", UserName = "y215012068@sakarya.edu.tr" };

            if (userManager.FindByNameAsync("Admin").Result == null)
            {
                var identityResult = userManager.CreateAsync(admin, "sau").Result;
            }
            if(roleManager.FindByNameAsync("Admin").Result == null)
            {
                IdentityRole role = new IdentityRole { Name = "Admin" };
                var identityResult = roleManager.CreateAsync(role).Result;

                var result = userManager.AddToRoleAsync(admin, role.Name).Result;
            }

        }
    }
}
