using System;
using Kaspersky.Backup.Client.Entities;
using Kaspersky.Retention.Models.Primitives;

namespace Kaspersky.Retention.Services.Helpers
{
    public static class GenerationsHelper
    {
        public static BackupGeneration GetGeneration(this BackupRecord record, DateTimeOffset currentDate)
            => GetGeneration(record.Created, currentDate);
        
        public static BackupGeneration GetGeneration(DateTimeOffset createdDate, DateTimeOffset currentDate)
        {
            var elapsedDays = (currentDate - createdDate).Days;

            if (elapsedDays > 14)
                return BackupGeneration.Third;

            if (elapsedDays > 7 && elapsedDays <= 14)
                return BackupGeneration.Second;
            
            if (elapsedDays > 3 && elapsedDays <= 7)
                return BackupGeneration.First;
            
            if (elapsedDays >= 0 && elapsedDays <= 3)
                return BackupGeneration.Zero;
            
            throw new InvalidOperationException("Elapsed days out of specified range.");
        }
    }
}