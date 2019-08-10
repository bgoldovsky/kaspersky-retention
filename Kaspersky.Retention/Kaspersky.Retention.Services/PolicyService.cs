using System;
using System.Threading;
using System.Threading.Tasks;
using Kaspersky.Backup.Client.Contracts;
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
        

        public PolicyService(
            ILogger<PolicyService> logger,
            IBackupServiceClient client, 
            IClock clock,
            IOptions<PolicyServiceConfiguration> options)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _client = client ?? throw new ArgumentNullException(nameof(logger));
            _clock = clock ?? throw new ArgumentNullException(nameof(clock));
            
            
        }
        
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            throw new System.NotImplementedException();
        }
    }
}