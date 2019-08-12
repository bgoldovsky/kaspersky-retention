using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Kaspersky.Backup.Client;
using Kaspersky.Backup.Client.Contracts;
using Kaspersky.Retention.Models.Configurations;
using Kaspersky.Retention.Services.Tests.Fakes;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using Xunit;

namespace Kaspersky.Retention.Services.Tests
{
    
    public sealed class PolicyServiceTests
    {
        private readonly IBackupServiceClient _client;
        private readonly PolicyService _service;
        
        public PolicyServiceTests()
        {
            var logger = NullLoggerFactory.Instance.CreateLogger<PolicyService>();
            var options = Options.Create(new PolicyServiceConfiguration { Interval = TimeSpan.FromHours(1)});
            
            _client = new BackupServiceClient();
            _service = new PolicyService(logger, _client, new FakeClock(), options);
        }

        [Fact]
        public async Task PolicyApplied_Success()
        {
            foreach (var backup in BackupRecords.TwoWeekBackups)
                _client.Add(backup);

            var previousBackups = _client.Get();
            previousBackups.Should().HaveCount(32);

            await _service.StartAsync(CancellationToken.None);
            await _service.StopAsync(CancellationToken.None);
            
            var actual = _client.Get();
            actual.Should().HaveCount(13);
        }
        
        [Fact]
        public async Task PolicyApplied_NothingToRemove()
        {
            foreach (var backup in BackupRecords.ActualBackups)
                _client.Add(backup);

            var previousBackups = _client.Get();
            previousBackups.Should().HaveCount(13);

            await _service.StartAsync(CancellationToken.None);
            await _service.StopAsync(CancellationToken.None);
            
            var actual = _client.Get();
            actual.Should().HaveCount(13);
        }
        
        [Fact]
        public async Task PolicyApplied_ValidDates()
        {
            var day0 = BackupRecords.CurrentDate;
            var day3 = BackupRecords.CurrentDate.AddDays(-3);
            var day7 = BackupRecords.CurrentDate.AddDays(-7);
            var day14 = BackupRecords.CurrentDate.AddDays(-14);
            
            foreach (var backup in BackupRecords.TwoWeekBackups)
                _client.Add(backup);
            
            await _service.StartAsync(CancellationToken.None);
            await _service.StopAsync(CancellationToken.None);
            
            var actual = _client.Get();
            
            // keep no more than 4 backups 0-3 days old
            actual.Where(x => x.Created <= day0 && x.Created >= day3)
                .Should().HaveCount(4);
            
            // keep no more than 4 backups 3-7 days old
            actual.Where(x => x.Created <= day3 && x.Created >= day7)
                .Should().HaveCount(4);
            
            // keep no more than 4 backups 7-14 days old
            actual.Where(x => x.Created <= day7 && x.Created >= day14)
                .Should().HaveCount(4);

            // keep 1 backup older than 14 days
            actual.Where(x => x.Created < day14)
                .Should().HaveCount(1);
        }
    }
}