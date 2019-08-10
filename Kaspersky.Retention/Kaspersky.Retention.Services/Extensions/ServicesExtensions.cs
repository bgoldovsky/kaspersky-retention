using Kaspersky.Retention.Models.Configurations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Kaspersky.Retention.Services.Extensions
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddServices(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.Configure<PolicyServiceConfiguration>(configuration.GetSection("PolicyService"));
            
            return services.AddHostedService<PolicyService>();
        }
    }
}