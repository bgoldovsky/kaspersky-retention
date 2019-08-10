using System;
using System.Collections.Generic;
using System.Linq;
using Kaspersky.Backup.Client.Entities;
using Kaspersky.Retention.Models.Primitives;
using Kaspersky.Retention.Services.Helpers;

namespace Kaspersky.Retention.Services
{
    public class BackupFilter
    {
        private readonly IReadOnlyCollection<BackupRecord> _backups;
        private readonly DateTimeOffset _currentDate;

        public BackupFilter(
            IReadOnlyCollection<BackupRecord> backups,
            DateTimeOffset currentDate)
        {
            _backups = backups;
            _currentDate = currentDate;
        }
        
        public IReadOnlyCollection<Guid> GetIdsToRemove()
        {
            var result = new List<Guid>();

            var generations = _backups
                .OrderByDescending(x => x.Created)
                .GroupBy(x => x.GetGeneration(_currentDate));
            
            foreach (var generation in generations)
            {
                switch (generation.Key)
                {
                    case BackupGeneration.Third:
                        result.AddRange(generation.Skip(1).Select(x => x.Id));
                        break;
                    
                    case BackupGeneration.Second:
                    case BackupGeneration.First:
                    case BackupGeneration.Zero:
                        result.AddRange(generation.Skip(4).Select(x => x.Id));
                        break;
                    
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            return result;
        }
    }
}