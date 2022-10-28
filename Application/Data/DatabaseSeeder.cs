using Application.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Data
{
    public static class DatabaseSeeder
    {
        public static async Task Seed(IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();
            var dbContext = serviceProvider.GetRequiredService<ApplicationDbContext>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<ApplicationRole>>();

            await SeedRolesAsync(roleManager);
            await SeedUsersAsync(userManager);            
        }
        private static async Task SeedRolesAsync(RoleManager<ApplicationRole> roleManager)
        {
            if (roleManager.Roles.Any()) { return; }
            await roleManager.CreateAsync(new ApplicationRole()
            {
                Name = RoleNameConstants.SysAdmin,
                DisplayName = "System Administrator",
                HomePageUrl = "/Admin/Dashboard",
                CanAccessEveryting = true,
                LastModifiedOn = DateTime.UtcNow,
            });
            await roleManager.CreateAsync(new ApplicationRole()
            {
                Name = RoleNameConstants.Tutor,
                DisplayName = "Tutor",
                HomePageUrl = "/Tutors/Dashboard"
            });
            await roleManager.CreateAsync(new ApplicationRole()
            {
                Name = RoleNameConstants.Tutee,
                DisplayName = "Tutee",
                HomePageUrl = "/Tutees/Dashboard"
            });           
        }
        private static async Task SeedUsersAsync(UserManager<ApplicationUser> userManager)
        {
            if (userManager.Users.Any()) { return; }
            var applicationUser = new ApplicationUser
            {
                FullName = "Vikas Bharadwaj",
                UserName = "admin@admin.com",
                Email = "admin@admin.com",
                IsActive = true,
                EmailConfirmed = true,
            };
            await userManager.CreateAsync(applicationUser, "Admin@12");
            await userManager.AddToRoleAsync(applicationUser, RoleNameConstants.SysAdmin);
            var user = new ApplicationUser
            {
                FullName = "Vikas",
                UserName = "user@user.com",
                Email = "user@user.com"
            };
            await userManager.CreateAsync(user, "vikas@12");
            var roles = new List<string> { RoleNameConstants.Tutor, RoleNameConstants.Tutee };
            await userManager.AddToRolesAsync(user, roles);
        }       
    }
}
