using System;
using System.Collections.Generic;
using System.Linq;
using Kaspersky.Backup.Client.Contracts;
using Kaspersky.Backup.Client.Entities;
using Kaspersky.Retention.Models.Primitives;
using Kaspersky.Retention.Services.Helpers;
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
                
                // Пробрасываем исключение наверх для ретраинга Hangfire
                throw;
            }
        }

        //TODO: Перенести в сервис политик
        private void RemoveObsoleteBackups(DateTimeOffset currentDate)
        {
            var list = _client.Get();

            var groupedList = list
                .OrderByDescending(x => x.Created)
                .GroupBy(x => x.GetGeneration(currentDate));

            var backupsToRemove = new List<Guid>();
            
            foreach (var group in groupedList)
            {
                switch (group.Key)
                {
                    case BackupGeneration.Third:
                        backupsToRemove.AddRange(group.Skip(1).Select(x => x.Id));
                        break;
                    
                    case BackupGeneration.Second:
                    case BackupGeneration.First:
                    case BackupGeneration.Zero:
                        backupsToRemove.AddRange(group.Skip(4).Select(x => x.Id));
                        break;
                    
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            foreach (var id in backupsToRemove)
                _client.Remove(id);
        }
    }
}