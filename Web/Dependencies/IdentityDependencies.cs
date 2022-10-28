using Application.Data;
using Application.Identity;
using Microsoft.AspNetCore.Identity;

namespace Web.Dependencies
{
    public static class IdentityDependencies
    {
        public static void Register(IServiceCollection services)
        {
            services.AddIdentity<ApplicationUser, ApplicationRole>(
                options =>
                {
                    options.SignIn.RequireConfirmedEmail = true;

                })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddTokenProvider<DataProtectorTokenProvider<ApplicationUser>>(TokenOptions.DefaultProvider);



        }
    }
}
