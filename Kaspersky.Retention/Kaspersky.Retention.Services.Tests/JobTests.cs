using System.Linq;
using FluentAssertions;
using Kaspersky.Backup.Client;
using Kaspersky.Backup.Client.Contracts;
using Kaspersky.Retention.Models.Primitives;
using Kaspersky.Retention.Services.Extensions;
using Kaspersky.Retention.Services.Jobs;
using Kaspersky.Retention.Services.Tests.Fakes;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Xunit;

namespace Kaspersky.Retention.Services.Tests
{
    public sealed class JobTests
    {
        private readonly IBackupServiceClient _client;
        private readonly FakeClock _clock = new FakeClock();
        private readonly BackupJob _job;
        
        public JobTests()
        {
            var logger = NullLoggerFactory.Instance.CreateLogger<BackupJob>();
            
            _client = new BackupServiceClient();
            _job = new BackupJob(logger, _client, _clock);
        }
        
        [Fact]
        public void BackupWorking_Success()
        {
            for (var i = 0; i <= 1000; i++)
            {
                _clock.AddHours(12);
                _job.CreateBackup();
                
                var backups = _client.Get().GroupBy(x => x.GetGeneration(_clock.Now));
                foreach (var backup in backups)
                    backup.Count().Should().BeLessOrEqualTo(backup.Key == BackupGeneration.Third ? 1 : 4);
            }
        }

        [Fact]
        public void PolicyApplied_Success()
        {
            foreach (var backup in BackupRecords.TwoWeekBackups)
                _client.Add(backup);

            var previousBackups = _client.Get();
            previousBackups.Should().HaveCount(32);

            _job.CreateBackup();

            var actual = _client.Get();
            actual.Should().HaveCount(11);
        }
        
        [Fact]
        public void PolicyApplied_NothingToRemove()
        {
            foreach (var backup in BackupRecords.NothingToRemove)
                _client.Add(backup);
            
            var previousBackups = _client.Get();
            previousBackups.Should().HaveCount(10);

            _job.CreateBackup();
            
            var actual = _client.Get();
            actual.Should().HaveCount(11);
        }
        
        [Fact]
        public void PolicyApplied_PrepareToBackup()
        {
            foreach (var backup in BackupRecords.ActualBackups)
                _client.Add(backup);

            var previousBackups = _client.Get();
            previousBackups.Should().HaveCount(13);

            _job.CreateBackup();
            
            var actual = _client.Get();
            actual.Should().HaveCount(11);
        }
    }
}