using Advanced_Database_and_ORM_Concepts_SD_330_W22SD.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Advanced_Database_and_ORM_Concepts_SD_330_W22SD.Models
{
    public static class SeedData
    {
        public async static Task Initialize(IServiceProvider serviceProvider)
        {
            ApplicationDbContext context = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>());

            RoleManager<IdentityRole> roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();   
            
            UserManager<ApplicationUser> userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            List<string> roles = new List<string> { "Admin", "User" };

            if (!context.Roles.Any())
            {
                foreach(string role in roles)
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }

                await context.SaveChangesAsync();
            }

            if (!context.Users.Any())
            {
                ApplicationUser seededUser1 = new ApplicationUser
                {
                    Email = "Kelvin@gmail.ca",
                    NormalizedEmail = "KELVIN@GMAIL.CA",
                    UserName = "Kelvin@gmail.ca",
                    NormalizedUserName = "KELVIN@GMAIL.CA",
                    EmailConfirmed = true,
                };

                var password1 = new PasswordHasher<IdentityUser>();
                var hashed1 = password1.HashPassword(seededUser1, "P@ssword1");
                seededUser1.PasswordHash = hashed1;

                await userManager.CreateAsync(seededUser1);
                await userManager.AddToRoleAsync(seededUser1, "Administrator");

                ApplicationUser seededUser2 = new ApplicationUser
                {
                    Email = "nick@gmail.ca",
                    NormalizedEmail = "NICK@GMAIL.CA",
                    UserName = "nick@gmail.ca",
                    NormalizedUserName = "NICK@GMAIL.CA",
                    EmailConfirmed = true,
                };

                var password2 = new PasswordHasher<IdentityUser>();
                var hashed2 = password2.HashPassword(seededUser2, "P@ssword2");
                seededUser2.PasswordHash = hashed2;

                await userManager.CreateAsync(seededUser2);
                await userManager.AddToRoleAsync(seededUser2, "Administrator");

                ApplicationUser seededUser3 = new ApplicationUser
                {
                    Email = "grass@gmail.ca",
                    NormalizedEmail = "GRASS@GMAIL.CA",
                    UserName = "grass@gmail.ca",
                    NormalizedUserName = "GRASS@GMAIL.CA",
                    EmailConfirmed = true,
                };

                var password3 = new PasswordHasher<IdentityUser>();
                var hashed3 = password3.HashPassword(seededUser3, "P@ssword3");
                seededUser3.PasswordHash = hashed3;

                await userManager.CreateAsync(seededUser3);
                await userManager.AddToRoleAsync(seededUser3, "Administrator");
            }

            await context.SaveChangesAsync();
        }
    }
}
