using Microsoft.AspNetCore.Identity;

namespace SistemaEstoque.Data
{
    public class IdentitySeeder
    {
        public static async Task CriarRolesEUsuarioAdminAsync(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            string[] roles = { "Admin", "Estoquista" };

            foreach (var role in roles)
            {
                var roleExist = await roleManager.RoleExistsAsync(role);

                if (!roleExist)
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            var adminEmail = "admin@gmail.com";
            var adminUser = await userManager.FindByEmailAsync(adminEmail);

            if(adminUser == null)
            {
                var user = new IdentityUser
                {
                    UserName = adminEmail,
                    Email = adminEmail
                };

                var result = await userManager.CreateAsync(user, "Admin@123");

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "Admin");
                }
            }

            var estoquistaEmail = "estoquista@gmail.com";
            var estoquistaUser = await userManager.FindByEmailAsync(estoquistaEmail);

            if (estoquistaUser == null)
            {
                var user = new IdentityUser
                {
                    UserName = estoquistaEmail,
                    Email = estoquistaEmail
                };

                var result = await userManager.CreateAsync(user, "Estoquista@123");

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "Estoquista");
                }
            }
        }
    }
}
