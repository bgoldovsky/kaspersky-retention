using System;
using SharpJuice.Essentials;

namespace Kaspersky.Retention.Services.Tests.Fakes
{
    public class FakeClock : IClock
    {
        public DateTimeOffset Now => BackupRecords.CurrentDate;
    }
}