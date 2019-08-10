using Microsoft.Extensions.DependencyInjection;

namespace Kaspersky.Retention.Services.Extensions
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
            => services.AddHostedService<PolicyService>();
    }
}