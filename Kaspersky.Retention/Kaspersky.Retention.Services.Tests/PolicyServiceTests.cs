using System;
using AutoFixture;
using Kaspersky.Backup.Client;
using Kaspersky.Retention.Models.Configurations;
using Kaspersky.Retention.Services.Tests.Fakes;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using SharpJuice.Essentials;
using Xunit;

namespace Kaspersky.Retention.Services.Tests
{
    /*
    public sealed class PolicyServiceTests
    {
        private readonly PolicyService _service;
        
        public PolicyServiceTests()
        {
            var fixture = new Fixture();
            
            var logger = NullLoggerFactory.Instance.CreateLogger<PolicyService>();
            
            var client = new BackupServiceClient();
            foreach (var backup in BackupRecords.TwoWeekBackups)
                client.Add(backup);
            
            var clock = fixture.Build<IClock>()
                .With(x => x.Now, BackupRecords.CurrentDate)
                .Create();

            var options = Options.Create(new PolicyServiceConfiguration { Interval = TimeSpan.FromMinutes(1)});
   
            
            _service = new PolicyService(logger, client, clock, options);
        }

        [Fact]
        public void DoTest()
        {
            
        }
    }
        */
}