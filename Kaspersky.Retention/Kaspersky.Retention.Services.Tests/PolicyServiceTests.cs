using System;
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
    }
}