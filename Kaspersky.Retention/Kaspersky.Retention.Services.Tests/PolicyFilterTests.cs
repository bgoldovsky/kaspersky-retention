using System.Linq;
using FluentAssertions;
using Kaspersky.Retention.Services.Tests.Fakes;
using Xunit;

namespace Kaspersky.Retention.Services.Tests
{
    public sealed class PolicyFilterTests
    {
        [Fact]
        public void Filter_NothingToRemove()
        {
            var filter = new PolicyFilter(BackupRecords.TwoWeekBackups, BackupRecords.CurrentDate);
            
            var idsToRemove = filter.GetIdsToRemove();
            var actualIds = BackupRecords.TwoWeekBackups
                .Select(x => x.Id)
                .Except(idsToRemove)
                .ToArray();
            
            idsToRemove.Should().HaveCount(19);
            actualIds.Should().HaveCount(13);
        }
        
        [Fact]
        public void Filter_ObsoleteRemoved()
        {
            var filter = new PolicyFilter(BackupRecords.ActualBackups, BackupRecords.CurrentDate);
            
            var idsToRemove = filter.GetIdsToRemove();
            var actualIds = BackupRecords.ActualBackups
                .Select(x => x.Id)
                .Except(idsToRemove)
                .ToArray();
            
            idsToRemove.Should().HaveCount(0);
            actualIds.Should().HaveCount(13);
        }
    }
}