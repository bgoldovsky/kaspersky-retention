using System;
using System.Linq;
using FluentAssertions;
using Kaspersky.Retention.Services.Tests.Fakes;
using Xunit;

namespace Kaspersky.Retention.Services.Tests
{
    public sealed class PoliticianTests
    {
        [Fact]
        public void Politician_NothingToRemove()
        {
            var politician = new Politician(BackupRecords.ActualBackups, BackupRecords.CurrentDate);

            var idsToRemove = politician.GetIdsToRemove();
            var actualIds = BackupRecords.ActualBackups
                .Select(x => x.Id)
                .Except(idsToRemove)
                .ToArray();

            idsToRemove.Should().HaveCount(0);
            actualIds.Should().HaveCount(13);
        }

        [Fact]
        public void Politician_ObsoleteRemoved()
        {
            var politician = new Politician(BackupRecords.TwoWeekBackups, BackupRecords.CurrentDate);

            var idsToRemove = politician.GetIdsToRemove();
            var actualIds = BackupRecords.TwoWeekBackups
                .Select(x => x.Id)
                .Except(idsToRemove)
                .ToArray();

            idsToRemove.Should().HaveCount(19);
            actualIds.Should().HaveCount(13);
        }

        [Fact]
        public void Politician_ObsoleteRemoved_ActualCheck()
        {
            var politician = new Politician(BackupRecords.TwoWeekBackups, BackupRecords.CurrentDate);

            var idsToRemove = politician.GetIdsToRemove();
            var actualIds = BackupRecords.TwoWeekBackups
                .Select(x => x.Id)
                .Except(idsToRemove)
                .ToArray();

            var expected = new[]
            {
                new Guid("53afa98d-c280-4ee3-8228-79dcd4c3dd18"),
                new Guid("53afa98d-c280-4ee3-8228-79dcd4c3dd19"),
                new Guid("53afa98d-c280-4ee3-8228-79dcd4c3dd20"),
                new Guid("53afa98d-c280-4ee3-8228-79dcd4c3dd21"),
                new Guid("53afa98d-c280-4ee3-8228-79dcd4c3dd26"),
                new Guid("53afa98d-c280-4ee3-8228-79dcd4c3dd27"),
                new Guid("53afa98d-c280-4ee3-8228-79dcd4c3dd28"),
                new Guid("53afa98d-c280-4ee3-8228-79dcd4c3dd29"),
                new Guid("53afa98d-c280-4ee3-8228-79dcd4c3dd34"),
                new Guid("53afa98d-c280-4ee3-8228-79dcd4c3dd35"),
                new Guid("53afa98d-c280-4ee3-8228-79dcd4c3dd36"),
                new Guid("53afa98d-c280-4ee3-8228-79dcd4c3dd37"),
                new Guid("53afa98d-c280-4ee3-8228-79dcd4c3dd48")
            };
            
            actualIds.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Politician_ObsoleteRemoved_RemovedCheck()
        {
            var politician = new Politician(BackupRecords.TwoWeekBackups, BackupRecords.CurrentDate);

            var idsToRemove = politician.GetIdsToRemove();
       
            var expected = new[]
            {
                new Guid("53afa98d-c280-4ee3-8228-79dcd4c3dd22"),
                new Guid("53afa98d-c280-4ee3-8228-79dcd4c3dd23"),
                new Guid("53afa98d-c280-4ee3-8228-79dcd4c3dd24"),
                new Guid("53afa98d-c280-4ee3-8228-79dcd4c3dd25"),
                new Guid("53afa98d-c280-4ee3-8228-79dcd4c3dd30"),
                new Guid("53afa98d-c280-4ee3-8228-79dcd4c3dd31"),
                new Guid("53afa98d-c280-4ee3-8228-79dcd4c3dd32"),
                new Guid("53afa98d-c280-4ee3-8228-79dcd4c3dd33"),
                new Guid("53afa98d-c280-4ee3-8228-79dcd4c3dd38"),
                new Guid("53afa98d-c280-4ee3-8228-79dcd4c3dd39"),
                new Guid("53afa98d-c280-4ee3-8228-79dcd4c3dd40"),
                new Guid("53afa98d-c280-4ee3-8228-79dcd4c3dd41"),
                new Guid("53afa98d-c280-4ee3-8228-79dcd4c3dd42"),
                new Guid("53afa98d-c280-4ee3-8228-79dcd4c3dd43"),
                new Guid("53afa98d-c280-4ee3-8228-79dcd4c3dd44"),
                new Guid("53afa98d-c280-4ee3-8228-79dcd4c3dd45"),
                new Guid("53afa98d-c280-4ee3-8228-79dcd4c3dd46"),
                new Guid("53afa98d-c280-4ee3-8228-79dcd4c3dd47"),
                new Guid("53afa98d-c280-4ee3-8228-79dcd4c3dd49")
            };

            idsToRemove.Should().BeEquivalentTo(expected);
        }
    }
}