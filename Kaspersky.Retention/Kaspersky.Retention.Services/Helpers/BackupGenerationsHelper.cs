using System;
using Kaspersky.Backup.Client.Entities;
using Kaspersky.Retention.Models.Primitives;

namespace Kaspersky.Retention.Services.Helpers
{
    public static class BackupGenerationsHelper
    {
        public static BackupGeneration GetGeneration(this BackupRecord record, DateTimeOffset currentDate)
            => GetGeneration(record.Created, currentDate);
        
        public static BackupGeneration GetGeneration(DateTimeOffset createdDate, DateTimeOffset currentDate)
        {
            var elapsed = currentDate - createdDate;
            
            if (elapsed.TotalMilliseconds < 0)
                throw new InvalidOperationException("Elapsed can't be negative.");

            if (elapsed.Days >= 0 && elapsed.Days <= 3)
                return BackupGeneration.Zero;
            
            if (elapsed.Days >= 4 && elapsed.Days <= 7)
                return BackupGeneration.First;
            
            if (elapsed.Days >= 8 && elapsed.Days <= 14)
                return BackupGeneration.Second;
            
            if (elapsed.Days > 14)
                return BackupGeneration.Third;
            
            throw new InvalidOperationException($"Elapsed days {elapsed.Days} out of range.");
        }
    }
}