using System;
using Hangfire;
using Hangfire.MemoryStorage;
using Kaspersky.Retention.Models.Configurations;
using Kaspersky.Retention.Services.Jobs;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Kaspersky.Retention.Services.Extensions
{
    /*
        В production-коде вместо in-memory используем Hangfire с СУБД 
        для сохранения расписания в случае перезагрузки и синхронизации между экземплярами сервиса
    */
    public static class SchedulerExtensions
    {
        public static IServiceCollection AddScheduler(
            this IServiceCollection services, 
            IConfiguration configuration)
        { 
            GlobalJobFilters.Filters.Add(new AutomaticRetryAttribute { Attempts = 5 });
            var inMemory = GlobalConfiguration.Configuration.UseMemoryStorage();
            services.AddHangfire(x => x.UseStorage(inMemory));

            var jobConfiguration = configuration.GetSection("RetentionBackupJob").Get<JobConfiguration>();
            AddJob(jobConfiguration);
            
            return services;
        }

        public static IApplicationBuilder UseScheduler(this IApplicationBuilder app)
            => app.UseHangfireDashboard()
                .UseHangfireServer();

        private static void AddJob(JobConfiguration jobConfiguration)
        {
            if (string.IsNullOrWhiteSpace(jobConfiguration.Cron))
                throw new ArgumentException("Cron not specified.");

            RecurringJob.AddOrUpdate<BackupJob>(
                nameof(BackupJob), 
                r => r.CreateBackup(), 
                jobConfiguration.Cron, 
                TimeZoneInfo.Utc);
        }
    }
}