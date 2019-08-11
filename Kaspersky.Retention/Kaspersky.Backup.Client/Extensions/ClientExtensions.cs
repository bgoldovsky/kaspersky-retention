using Kaspersky.Backup.Client.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace Kaspersky.Backup.Client.Extensions
{
    public static class ClientExtensions
    {
        public static IServiceCollection AddBackupClient(this IServiceCollection services)
            => services.AddSingleton<IBackupServiceClient, BackupServiceClient>();
    }
}