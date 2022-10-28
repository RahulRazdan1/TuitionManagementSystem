using Application.Common;
using Application.Emails;
using Web.Common;

namespace Web.Dependencies
{
    public static class ApplicationDependencies
    {
        public static void Register(IServiceCollection services)
        {
            services.AddScoped<Providers>();
            services.AddScoped<UserContext>();
            services.AddScoped<IEmailer, Emailer>();
        }
    }
}
