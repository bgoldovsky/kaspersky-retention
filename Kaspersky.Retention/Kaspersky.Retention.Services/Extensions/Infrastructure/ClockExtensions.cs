using Microsoft.Extensions.DependencyInjection;
using SharpJuice.Essentials;

namespace Kaspersky.Retention.Services.Extensions.Infrastructure
{
    public static class ClockExtensions
    {
        public static IServiceCollection AddClock(this IServiceCollection services)
            => services.AddSingleton<IClock, Clock>();
    }
}