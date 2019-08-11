using System;

namespace Kaspersky.Retention.Services.Tests.Fakes
{
    public class DateTimeRandom
    {
        private readonly Random _gen = new Random();

        public DateTimeOffset GetRandomDay(DateTimeOffset? startDate = default)
        {
            var start = startDate?.Date ?? new DateTime(1970, 1, 1);
            var range = (DateTime.Today - start).Days;    
            
            var randomDate = start.AddDays(_gen.Next(range));
            
            return new DateTimeOffset(randomDate);
        }
    }
}