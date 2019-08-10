using System;
using Kaspersky.Backup.Client.Contracts;
using Kaspersky.Backup.Client.Entities;
using Microsoft.Extensions.Logging;
using SharpJuice.Essentials;

namespace Kaspersky.Retention.Services.Jobs
{
    internal sealed class BackupJob
    {
        private readonly ILogger<BackupJob> _logger;
        private readonly IBackupServiceClient _client;
        private readonly IClock _clock;
        

        public BackupJob(
            ILogger<BackupJob> logger,
            IBackupServiceClient client, 
            IClock clock)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _client = client ?? throw new ArgumentNullException(nameof(logger));
            _clock = clock ?? throw new ArgumentNullException(nameof(clock));
        }

        public void CreateBackup()
        {
            try
            {
                var backup = new BackupRecord(Guid.NewGuid(), _clock.Now);
            
                _client.Add(backup);   
            
                _logger.LogInformation($"Backup created. Id: {backup.Id}. Created at: {backup.Created}");
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Backup error.");
                throw;
            }
        }
    }
}