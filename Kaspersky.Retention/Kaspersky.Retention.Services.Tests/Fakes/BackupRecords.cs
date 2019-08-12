using System;
using System.Collections.Generic;
using Kaspersky.Backup.Client.Entities;

namespace Kaspersky.Retention.Services.Tests.Fakes
{
    public static class BackupRecords
    {
        //2019-08-10 22:00:00
        public static DateTimeOffset CurrentDate => new DateTimeOffset(2019, 08, 10, 22, 0, 0, TimeSpan.Zero);
        
        public static IReadOnlyCollection<BackupRecord> TwoWeekBackups
            => new List<BackupRecord>
            {
                // 0 gen
                new BackupRecord(
                    new Guid("53afa98d-c280-4ee3-8228-79dcd4c3dd18"), 
                    new DateTimeOffset(2019, 8, 10, 20, 0,0, TimeSpan.Zero)),
                
                new BackupRecord(
                    new Guid("53afa98d-c280-4ee3-8228-79dcd4c3dd19"), 
                    new DateTimeOffset(2019, 8, 10, 8, 0,0, TimeSpan.Zero)),
                
                new BackupRecord(
                    new Guid("53afa98d-c280-4ee3-8228-79dcd4c3dd20"), 
                    new DateTimeOffset(2019, 8, 9, 20, 0,0, TimeSpan.Zero)),
                
                new BackupRecord(
                    new Guid("53afa98d-c280-4ee3-8228-79dcd4c3dd21"), 
                    new DateTimeOffset(2019, 8, 9, 8, 0,0, TimeSpan.Zero)),
                
                new BackupRecord(
                    new Guid("53afa98d-c280-4ee3-8228-79dcd4c3dd22"), 
                    new DateTimeOffset(2019, 8, 8, 20, 0,0, TimeSpan.Zero)),
                
                new BackupRecord(
                    new Guid("53afa98d-c280-4ee3-8228-79dcd4c3dd23"), 
                    new DateTimeOffset(2019, 8, 8, 8, 0,0, TimeSpan.Zero)),
                
                new BackupRecord(
                    new Guid("53afa98d-c280-4ee3-8228-79dcd4c3dd24"), 
                    new DateTimeOffset(2019, 8, 7, 20, 0,0, TimeSpan.Zero)),
                
                new BackupRecord(
                    new Guid("53afa98d-c280-4ee3-8228-79dcd4c3dd25"), 
                    new DateTimeOffset(2019, 8, 7, 8, 0,0, TimeSpan.Zero)),

                // 1st gen
                new BackupRecord(
                    new Guid("53afa98d-c280-4ee3-8228-79dcd4c3dd26"), 
                    new DateTimeOffset(2019, 8, 6, 20, 0,0, TimeSpan.Zero)),
                
                new BackupRecord(
                    new Guid("53afa98d-c280-4ee3-8228-79dcd4c3dd27"), 
                    new DateTimeOffset(2019, 8, 6, 8, 0,0, TimeSpan.Zero)),
                
                new BackupRecord(
                    new Guid("53afa98d-c280-4ee3-8228-79dcd4c3dd28"), 
                    new DateTimeOffset(2019, 8, 5, 20, 0,0, TimeSpan.Zero)),
                
                new BackupRecord(
                    new Guid("53afa98d-c280-4ee3-8228-79dcd4c3dd29"), 
                    new DateTimeOffset(2019, 8, 5, 8, 0,0, TimeSpan.Zero)),
                
                new BackupRecord(
                    new Guid("53afa98d-c280-4ee3-8228-79dcd4c3dd30"), 
                    new DateTimeOffset(2019, 8, 4, 20, 0,0, TimeSpan.Zero)),
                
                new BackupRecord(
                    new Guid("53afa98d-c280-4ee3-8228-79dcd4c3dd31"), 
                    new DateTimeOffset(2019, 8, 4, 8, 0,0, TimeSpan.Zero)),
                
                new BackupRecord(
                    new Guid("53afa98d-c280-4ee3-8228-79dcd4c3dd32"), 
                    new DateTimeOffset(2019, 8, 3, 20, 0,0, TimeSpan.Zero)),
                
                new BackupRecord(
                    new Guid("53afa98d-c280-4ee3-8228-79dcd4c3dd33"), 
                    new DateTimeOffset(2019, 8, 3, 8, 0,0, TimeSpan.Zero)),

                // 2ng gen
                new BackupRecord(
                    new Guid("53afa98d-c280-4ee3-8228-79dcd4c3dd34"), 
                    new DateTimeOffset(2019, 8, 2, 20, 0,0, TimeSpan.Zero)),
                
                new BackupRecord(
                    new Guid("53afa98d-c280-4ee3-8228-79dcd4c3dd35"), 
                    new DateTimeOffset(2019, 8, 2, 8, 0,0, TimeSpan.Zero)),
                
                new BackupRecord(
                    new Guid("53afa98d-c280-4ee3-8228-79dcd4c3dd36"), 
                    new DateTimeOffset(2019, 8, 1, 20, 0,0, TimeSpan.Zero)),
                
                new BackupRecord(
                    new Guid("53afa98d-c280-4ee3-8228-79dcd4c3dd37"), 
                    new DateTimeOffset(2019, 8, 1, 8, 0,0, TimeSpan.Zero)),
                
                new BackupRecord(
                    new Guid("53afa98d-c280-4ee3-8228-79dcd4c3dd38"), 
                    new DateTimeOffset(2019, 7, 31, 20, 0,0, TimeSpan.Zero)),
                
                new BackupRecord(
                    new Guid("53afa98d-c280-4ee3-8228-79dcd4c3dd39"), 
                    new DateTimeOffset(2019, 7, 31, 8, 0,0, TimeSpan.Zero)),
                
                new BackupRecord(
                    new Guid("53afa98d-c280-4ee3-8228-79dcd4c3dd40"), 
                    new DateTimeOffset(2019, 7, 30, 20, 0,0, TimeSpan.Zero)),
                
                new BackupRecord(
                    new Guid("53afa98d-c280-4ee3-8228-79dcd4c3dd41"), 
                    new DateTimeOffset(2019, 7, 30, 8, 0,0, TimeSpan.Zero)),
                
                new BackupRecord(
                    new Guid("53afa98d-c280-4ee3-8228-79dcd4c3dd42"), 
                    new DateTimeOffset(2019, 7, 29, 20, 0,0, TimeSpan.Zero)),
                
                new BackupRecord(
                    new Guid("53afa98d-c280-4ee3-8228-79dcd4c3dd43"), 
                    new DateTimeOffset(2019, 7, 29, 8, 0,0, TimeSpan.Zero)),
                
                new BackupRecord(
                    new Guid("53afa98d-c280-4ee3-8228-79dcd4c3dd44"), 
                    new DateTimeOffset(2019, 7, 28, 20, 0,0, TimeSpan.Zero)),
                
                new BackupRecord(
                    new Guid("53afa98d-c280-4ee3-8228-79dcd4c3dd45"), 
                    new DateTimeOffset(2019, 7, 28, 8, 0,0, TimeSpan.Zero)),
                
                new BackupRecord(
                    new Guid("53afa98d-c280-4ee3-8228-79dcd4c3dd46"), 
                    new DateTimeOffset(2019, 7, 27, 20, 0,0, TimeSpan.Zero)),
                
                new BackupRecord(
                    new Guid("53afa98d-c280-4ee3-8228-79dcd4c3dd47"), 
                    new DateTimeOffset(2019, 7, 27, 8, 0,0, TimeSpan.Zero)),
                
                // 3ng gen
                new BackupRecord(
                    new Guid("53afa98d-c280-4ee3-8228-79dcd4c3dd48"), 
                    new DateTimeOffset(2019, 7, 26, 20, 0,0, TimeSpan.Zero)),

                new BackupRecord(
                    new Guid("53afa98d-c280-4ee3-8228-79dcd4c3dd49"), 
                    new DateTimeOffset(2019, 7, 26, 8, 0,0, TimeSpan.Zero)),
            };
        
        public static IReadOnlyCollection<BackupRecord> ActualBackups
            => new List<BackupRecord>
            {
                // 0 gen
                new BackupRecord(
                    new Guid("53afa98d-c280-4ee3-8228-79dcd4c3dd18"), 
                    new DateTimeOffset(2019, 8, 10, 20, 0,0, TimeSpan.Zero)),
                
                new BackupRecord(
                    new Guid("53afa98d-c280-4ee3-8228-79dcd4c3dd19"), 
                    new DateTimeOffset(2019, 8, 10, 8, 0,0, TimeSpan.Zero)),
                
                new BackupRecord(
                    new Guid("53afa98d-c280-4ee3-8228-79dcd4c3dd20"), 
                    new DateTimeOffset(2019, 8, 9, 20, 0,0, TimeSpan.Zero)),
                
                new BackupRecord(
                    new Guid("53afa98d-c280-4ee3-8228-79dcd4c3dd21"), 
                    new DateTimeOffset(2019, 8, 9, 8, 0,0, TimeSpan.Zero)),

                // 1st gen
                new BackupRecord(
                    new Guid("53afa98d-c280-4ee3-8228-79dcd4c3dd26"), 
                    new DateTimeOffset(2019, 8, 6, 20, 0,0, TimeSpan.Zero)),
                
                new BackupRecord(
                    new Guid("53afa98d-c280-4ee3-8228-79dcd4c3dd27"), 
                    new DateTimeOffset(2019, 8, 6, 8, 0,0, TimeSpan.Zero)),
                
                new BackupRecord(
                    new Guid("53afa98d-c280-4ee3-8228-79dcd4c3dd28"), 
                    new DateTimeOffset(2019, 8, 5, 20, 0,0, TimeSpan.Zero)),
                
                new BackupRecord(
                    new Guid("53afa98d-c280-4ee3-8228-79dcd4c3dd29"), 
                    new DateTimeOffset(2019, 8, 5, 8, 0,0, TimeSpan.Zero)),
                
                // 2nd gen
                new BackupRecord(
                    new Guid("53afa98d-c280-4ee3-8228-79dcd4c3dd34"), 
                    new DateTimeOffset(2019, 8, 2, 20, 0,0, TimeSpan.Zero)),
                
                new BackupRecord(
                    new Guid("53afa98d-c280-4ee3-8228-79dcd4c3dd35"), 
                    new DateTimeOffset(2019, 8, 2, 8, 0,0, TimeSpan.Zero)),
                
                new BackupRecord(
                    new Guid("53afa98d-c280-4ee3-8228-79dcd4c3dd36"), 
                    new DateTimeOffset(2019, 8, 1, 20, 0,0, TimeSpan.Zero)),
                
                new BackupRecord(
                    new Guid("53afa98d-c280-4ee3-8228-79dcd4c3dd37"), 
                    new DateTimeOffset(2019, 8, 1, 8, 0,0, TimeSpan.Zero)),

                // 3rd gen
                new BackupRecord(
                    new Guid("53afa98d-c280-4ee3-8228-79dcd4c3dd48"), 
                    new DateTimeOffset(2019, 7, 26, 20, 0,0, TimeSpan.Zero))
            };
        
          public static IReadOnlyCollection<BackupRecord> NothingToRemove
            => new List<BackupRecord>
            {
                // 0 gen
                new BackupRecord(
                    new Guid("53afa98d-c280-4ee3-8228-79dcd4c3dd18"), 
                    new DateTimeOffset(2019, 8, 10, 20, 0,0, TimeSpan.Zero)),
                
                new BackupRecord(
                    new Guid("53afa98d-c280-4ee3-8228-79dcd4c3dd19"), 
                    new DateTimeOffset(2019, 8, 10, 8, 0,0, TimeSpan.Zero)),
                
                new BackupRecord(
                    new Guid("53afa98d-c280-4ee3-8228-79dcd4c3dd20"), 
                    new DateTimeOffset(2019, 8, 9, 20, 0,0, TimeSpan.Zero)),

                // 1st gen
                new BackupRecord(
                    new Guid("53afa98d-c280-4ee3-8228-79dcd4c3dd26"), 
                    new DateTimeOffset(2019, 8, 6, 20, 0,0, TimeSpan.Zero)),
                
                new BackupRecord(
                    new Guid("53afa98d-c280-4ee3-8228-79dcd4c3dd27"), 
                    new DateTimeOffset(2019, 8, 6, 8, 0,0, TimeSpan.Zero)),
                
                new BackupRecord(
                    new Guid("53afa98d-c280-4ee3-8228-79dcd4c3dd28"), 
                    new DateTimeOffset(2019, 8, 5, 20, 0,0, TimeSpan.Zero)),
                
                // 2nd gen
                new BackupRecord(
                    new Guid("53afa98d-c280-4ee3-8228-79dcd4c3dd34"), 
                    new DateTimeOffset(2019, 8, 2, 20, 0,0, TimeSpan.Zero)),
                
                new BackupRecord(
                    new Guid("53afa98d-c280-4ee3-8228-79dcd4c3dd35"), 
                    new DateTimeOffset(2019, 8, 2, 8, 0,0, TimeSpan.Zero)),
                
                new BackupRecord(
                    new Guid("53afa98d-c280-4ee3-8228-79dcd4c3dd36"), 
                    new DateTimeOffset(2019, 8, 1, 20, 0,0, TimeSpan.Zero)),
                
                // 3rd gen
                new BackupRecord(
                    new Guid("53afa98d-c280-4ee3-8228-79dcd4c3dd48"), 
                    new DateTimeOffset(2019, 7, 26, 20, 0,0, TimeSpan.Zero))
            };
    }
}