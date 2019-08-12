using System;
using SharpJuice.Essentials;

namespace Kaspersky.Retention.Services.Tests.Fakes
{
    public class FakeClock : IClock
    {
        private DateTimeOffset _currentDate = BackupRecords.CurrentDate;

        public DateTimeOffset Now => _currentDate;

        public void AddHours(int hours)
            => _currentDate = _currentDate.AddHours(hours);

        public void ToDefault()
            => _currentDate = BackupRecords.CurrentDate;
    }
}