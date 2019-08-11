using System;
using FluentAssertions;
using Kaspersky.Retention.Models.Primitives;
using Kaspersky.Retention.Services.Helpers;
using Xunit;

namespace Kaspersky.Retention.Services.Tests
{
    public class BackupGenerationsHelperTests
    {
        private readonly DateTimeOffset _currentDate = new DateTimeOffset(2019, 08, 10, 13, 10, 0, TimeSpan.Zero);
        
        [Theory]
        [InlineData(2019, 8, 10, 0, 0, 0)]
        [InlineData(2019, 8, 10, 13, 10, 0)]
        [InlineData(2019, 8, 9, 0, 0, 0)]
        [InlineData(2019, 8, 8, 0, 0, 0)]
        [InlineData(2019, 8, 7, 13, 10, 0)]
        public void GetGeneration_ZeroGen_Success(int year, int month, int day, int hour, int minute, int second)
        {
            var createdDate = new DateTimeOffset(year, month, day, hour, minute, second, TimeSpan.Zero);

            var actual = BackupGenerationsHelper.GetGeneration(createdDate, _currentDate);

            actual.Should().Be(BackupGeneration.Zero);
        }  
        
        [Theory]
        [InlineData(2019, 8, 7, 0, 0, 0)]
        [InlineData(2019, 8, 6, 0, 0, 0)]
        [InlineData(2019, 7, 6, 0, 0, 0)]
        public void GetGeneration_ZeroGen_Fail(int year, int month, int day, int hour, int minute, int second)
        {
            var createdDate = new DateTimeOffset(year, month, day, hour, minute, second, TimeSpan.Zero);
         
            var actual = BackupGenerationsHelper.GetGeneration(createdDate, _currentDate);

            actual.Should().NotBe(BackupGeneration.Zero);
        }  
        
        [Theory]
        [InlineData(2019, 8, 7, 0, 0, 0)]
        [InlineData(2019, 8, 6, 0, 0, 0)]
        [InlineData(2019, 8, 5, 0, 0, 0)]
        [InlineData(2019, 8, 4, 0, 0, 0)]
        [InlineData(2019, 8, 3, 13, 10, 0)]
        public void GetGeneration_FirstGen_Success(int year, int month, int day, int hour, int minute, int second)
        {
            var createdDate = new DateTimeOffset(year, month, day, hour, minute, second, TimeSpan.Zero);

            var actual = BackupGenerationsHelper.GetGeneration(createdDate, _currentDate);

            actual.Should().Be(BackupGeneration.First);
        }  
        
        [Theory]
        [InlineData(2019, 8, 10, 0, 0, 0)]
        [InlineData(2019, 8, 3, 0, 0, 0)]
        [InlineData(2019, 8, 2, 0, 0, 0)]
        public void GetGeneration_FirstGen_Fail(int year, int month, int day, int hour, int minute, int second)
        {
            var createdDate = new DateTimeOffset(year, month, day, hour, minute, second, TimeSpan.Zero);

            var actual = BackupGenerationsHelper.GetGeneration(createdDate, _currentDate);

            actual.Should().NotBe(BackupGeneration.First);
        }  
        
        [Theory]
        [InlineData(2019, 8, 3, 0, 0, 0)]
        [InlineData(2019, 8, 2, 0, 0, 0)]
        [InlineData(2019, 8, 1, 0, 0, 0)]
        [InlineData(2019, 7, 31, 0, 0, 0)]
        [InlineData(2019, 7, 30, 0, 0, 0)]
        [InlineData(2019, 7, 29, 0, 0, 0)]
        [InlineData(2019, 7, 28, 0, 0, 0)]
        [InlineData(2019, 7, 27, 13, 10, 0)]
        public void GetGeneration_SecondGen_Success(int year, int month, int day, int hour, int minute, int second)
        {
            var createdDate = new DateTimeOffset(year, month, day, hour, minute, second, TimeSpan.Zero);

            var actual = BackupGenerationsHelper.GetGeneration(createdDate, _currentDate);

            actual.Should().Be(BackupGeneration.Second);
        } 
        
        [Theory]
        [InlineData(2019, 8, 10, 0, 0, 0)]
        [InlineData(2019, 8, 7, 0, 0, 0)]
        [InlineData(2019, 7, 27, 0, 0, 0)]
        public void GetGeneration_SecondGen_Fail(int year, int month, int day, int hour, int minute, int second)
        {
            var createdDate = new DateTimeOffset(year, month, day, hour, minute, second, TimeSpan.Zero);

            var actual = BackupGenerationsHelper.GetGeneration(createdDate, _currentDate);

            actual.Should().NotBe(BackupGeneration.Second);
        } 
        
        [Theory]
        [InlineData(2019, 7, 27, 0, 0, 0)]
        [InlineData(2019, 7, 26, 0, 0, 0)]
        [InlineData(2019, 6, 27, 0, 0, 0)]
        [InlineData(2018, 7, 27, 0, 0, 0)]
        public void GetGeneration_ThirdGen_Success(int year, int month, int day, int hour, int minute, int second)
        {
            var createdDate = new DateTimeOffset(year, month, day, hour, minute, second, TimeSpan.Zero);

            var actual = BackupGenerationsHelper.GetGeneration(createdDate, _currentDate);

            actual.Should().Be(BackupGeneration.Third);
        } 
        
        [Fact]
        public void GetGeneration_ThirdGen_Fail()
        {
            var createdDate = new DateTimeOffset(2019, 8, 7, 0, 0, 0, TimeSpan.Zero);

            var actual = BackupGenerationsHelper.GetGeneration(createdDate, _currentDate);

            actual.Should().NotBe(BackupGeneration.Third);
        } 
        
        [Theory]
        [InlineData(2019, 08, 10, 13, 10, 10)]
        [InlineData(2019, 08, 11, 0, 0, 0)]
        [InlineData(2019, 09, 10, 0, 0, 0)]
        public void GetGeneration_Throw(int year, int month, int day, int hour, int minute, int second)
        {
            var createdDate = new DateTimeOffset(year, month, day, hour, minute, second, TimeSpan.Zero);
            
            Func<BackupGeneration> act = () => BackupGenerationsHelper.GetGeneration(createdDate, _currentDate);

            act.Should().Throw<InvalidOperationException>().WithMessage("Elapsed days*");
        }
    }
}