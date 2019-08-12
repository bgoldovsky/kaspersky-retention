using System;
using Kaspersky.Backup.Client.Contracts;
using Kaspersky.Backup.Client.Entities;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;
using SharpJuice.Essentials;

namespace Kaspersky.Retention.Services.Jobs
{
    public sealed class BackupJob
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
                ApplyPolicies();
                
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

        private void ApplyPolicies()
        {
            var backups = _client.Get();
            if (backups == null || !backups.Any())
            {
                _logger.LogWarning("Backups not found.");
                return;
            }
            
            var currentDate = _clock.Now;
            var politician = new Politician(backups, currentDate);
            
            var idsToRemove = politician.GetIdsToRemove();
            if (!idsToRemove.Any())
            {
                _logger.LogDebug($"Backups in actual state");
                return;
            }

            foreach (var id in idsToRemove)
            {
                _client.Remove(id);
                _logger.LogDebug($"Backup {id} was removed");
            }
        }
    }
}