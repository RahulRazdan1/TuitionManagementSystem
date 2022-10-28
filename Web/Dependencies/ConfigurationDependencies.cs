using Application.Emails;
using Web.Common;

namespace Web.Dependencies
{
    public static class ConfigurationDependencies
    {
        public static void RegisterAll(IServiceCollection services, IConfiguration configuration)
        {
          var emailSection = configuration.GetSection(AppConstants.EmailSection);
            services.Configure<EmailSettings>(emailSection);
        }
    }
}
