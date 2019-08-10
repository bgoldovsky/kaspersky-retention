using System;
using System.Threading;
using System.Threading.Tasks;
using Kaspersky.Backup.Client.Contracts;
using Kaspersky.Retention.Models.Configurations;
using Kaspersky.Retention.Services.Factories;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SharpJuice.Essentials;

namespace Kaspersky.Retention.Services
{
    public sealed class PolicyService : BackgroundService
    {
        private readonly ILogger<PolicyService> _logger;
        private readonly IBackupServiceClient _client;
        private readonly IClock _clock;
        private readonly TimeSpan _interval;

        public PolicyService(
            ILogger<PolicyService> logger,
            IBackupServiceClient client, 
            IClock clock,
            IOptions<PolicyServiceConfiguration> options)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _client = client ?? throw new ArgumentNullException(nameof(logger));
            _clock = clock ?? throw new ArgumentNullException(nameof(clock));
            
            if (options.Value.Interval.Equals(default))
                throw new ArgumentException("Interval not specified.");
            _interval = options.Value.Interval;
        }
        
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    var retryPolicy = RetryPolicyFactory.Create(); 
                    retryPolicy.Execute(ApplyPoliciesAsync);
                }
                catch (Exception e)
                {
                    _logger.LogError(e, "Apply policies to backup store was failed.");
                }

                await Task.Delay(_interval, stoppingToken);
            }
        }

        private void ApplyPoliciesAsync()
        {
            var backups = _client.Get();
            var currentDate = _clock.Now;
            var backupFilter = new BackupFilter(backups, currentDate);
            
            foreach (var id in backupFilter.GetIdsToRemove())
                _client.Remove(id);
        }
    }
}