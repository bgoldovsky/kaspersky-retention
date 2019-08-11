using System;
using FluentAssertions;
using Kaspersky.Retention.Models.Primitives;
using Kaspersky.Retention.Services.Helpers;
using Xunit;

namespace Kaspersky.Retention.Services.Tests
{
    public sealed class BackupGenerationsHelperTests
    {
        private readonly DateTimeOffset _currentDate = new DateTimeOffset(2019, 08, 10, 22, 0, 0, TimeSpan.Zero);
        
        [Theory]
        [InlineData(2019, 8, 10, 20, 0, 0)]
        [InlineData(2019, 8, 10, 8, 0, 0)]
        [InlineData(2019, 8, 9, 20, 0, 0)]
        [InlineData(2019, 8, 9, 8, 0, 0)]
        [InlineData(2019, 8, 8, 20, 0, 0)]
        [InlineData(2019, 8, 8, 8, 0, 0)]
        [InlineData(2019, 8, 7, 20, 0, 0)]
        [InlineData(2019, 8, 7, 8, 0, 0)]
        public void GetGeneration_ZeroGen_Success(int year, int month, int day, int hour, int minute, int second)
        {
            var createdDate = new DateTimeOffset(year, month, day, hour, minute, second, TimeSpan.Zero);

            var actual = BackupGenerationsHelper.GetGeneration(createdDate, _currentDate);

            actual.Should().Be(BackupGeneration.Zero);
        } 
        
        [Theory]
        [InlineData(2019, 8, 10, 22, 0, 0)]
        [InlineData(2019, 8, 6, 22, 0, 1)] 
        public void GetGeneration_ZeroGen_BoundedValues(int year, int month, int day, int hour, int minute, int second)
        {
            var createdDate = new DateTimeOffset(year, month, day, hour, minute, second, TimeSpan.Zero);

            var actual = BackupGenerationsHelper.GetGeneration(createdDate, _currentDate);

            actual.Should().Be(BackupGeneration.Zero);
        }  
        
        [Theory]
        [InlineData(2019, 8, 6, 22, 0, 0)] 
        [InlineData(2019, 8, 6, 20, 0, 0)]
        public void GetGeneration_ZeroGen_Fail(int year, int month, int day, int hour, int minute, int second)
        {
            var createdDate = new DateTimeOffset(year, month, day, hour, minute, second, TimeSpan.Zero);
         
            var actual = BackupGenerationsHelper.GetGeneration(createdDate, _currentDate);

            actual.Should().NotBe(BackupGeneration.Zero);
        }  
        
        [Theory]
        [InlineData(2019, 8, 6, 20, 0, 0)]
        [InlineData(2019, 8, 6, 8, 0, 0)]
        [InlineData(2019, 8, 5, 20, 0, 0)]
        [InlineData(2019, 8, 5, 8, 0, 0)]
        [InlineData(2019, 8, 4, 20, 0, 0)]
        [InlineData(2019, 8, 4, 8, 0, 0)]
        [InlineData(2019, 8, 3, 20, 0, 0)]
        [InlineData(2019, 8, 3, 8, 0, 0)]
        public void GetGeneration_FirstGen_Success(int year, int month, int day, int hour, int minute, int second)
        {
            var createdDate = new DateTimeOffset(year, month, day, hour, minute, second, TimeSpan.Zero);

            var actual = BackupGenerationsHelper.GetGeneration(createdDate, _currentDate);

            actual.Should().Be(BackupGeneration.First);
        }

        [Theory]
        [InlineData(2019, 8, 6, 22, 0, 0)]
        [InlineData(2019, 8, 2, 22, 0, 1)]
        public void GetGeneration_FirstGen_BoundedValues(int year, int month, int day, int hour, int minute, int second)
        {
            var createdDate = new DateTimeOffset(year, month, day, hour, minute, second, TimeSpan.Zero);

            var actual = BackupGenerationsHelper.GetGeneration(createdDate, _currentDate);

            actual.Should().Be(BackupGeneration.First);
        }  
        
        [Theory]
        [InlineData(2019, 8, 6, 22, 0, 1)]
        [InlineData(2019, 8, 2, 22, 0, 0)]
        public void GetGeneration_FirstGen_Fail(int year, int month, int day, int hour, int minute, int second)
        {
            var createdDate = new DateTimeOffset(year, month, day, hour, minute, second, TimeSpan.Zero);

            var actual = BackupGenerationsHelper.GetGeneration(createdDate, _currentDate);

            actual.Should().NotBe(BackupGeneration.First);
        }  
        
        [Theory]
        [InlineData(2019, 8, 2, 20, 0, 0)]
        [InlineData(2019, 8, 2, 8, 0, 0)]
        [InlineData(2019, 8, 1, 20, 0, 0)]
        [InlineData(2019, 8, 1, 8, 0, 0)]
        [InlineData(2019, 7, 31, 20, 0, 0)]
        [InlineData(2019, 7, 31, 8, 0, 0)]
        [InlineData(2019, 7, 30, 20, 0, 0)]
        [InlineData(2019, 7, 30, 8, 0, 0)]
        [InlineData(2019, 7, 29, 20, 0, 0)]
        [InlineData(2019, 7, 29, 8, 0, 0)]
        [InlineData(2019, 7, 28, 20, 0, 0)]
        [InlineData(2019, 7, 28, 8, 0, 0)]
        [InlineData(2019, 7, 27, 20, 0, 0)]
        [InlineData(2019, 7, 27, 8, 0, 0)]
        public void GetGeneration_SecondGen_Success(int year, int month, int day, int hour, int minute, int second)
        {
            var createdDate = new DateTimeOffset(year, month, day, hour, minute, second, TimeSpan.Zero);

            var actual = BackupGenerationsHelper.GetGeneration(createdDate, _currentDate);

            actual.Should().Be(BackupGeneration.Second);
        } 
        
        [Theory]
        [InlineData(2019, 8, 2, 22, 0, 0)]
        [InlineData(2019, 7, 26, 22, 0, 1)]
        public void GetGeneration_SecondGen_BoundedValues(int year, int month, int day, int hour, int minute, int second)
        {
            var createdDate = new DateTimeOffset(year, month, day, hour, minute, second, TimeSpan.Zero);

            var actual = BackupGenerationsHelper.GetGeneration(createdDate, _currentDate);

            actual.Should().Be(BackupGeneration.Second);
        }  
        
        [Theory]
        [InlineData(2019, 8, 2, 22, 0, 1)]
        [InlineData(2019, 7, 26, 22, 0, 0)]
        public void GetGeneration_SecondGen_Fail(int year, int month, int day, int hour, int minute, int second)
        {
            var createdDate = new DateTimeOffset(year, month, day, hour, minute, second, TimeSpan.Zero);

            var actual = BackupGenerationsHelper.GetGeneration(createdDate, _currentDate);

            actual.Should().NotBe(BackupGeneration.Second);
        } 
        
        [Theory]
        [InlineData(2019, 7, 26, 20, 0, 0)]
        [InlineData(2019, 7, 26, 8, 0, 0)]
        [InlineData(2019, 7, 25, 20, 0, 0)]
        [InlineData(2019, 7, 25, 8, 0, 0)]
        [InlineData(2018, 7, 25, 20, 0, 0)]
        [InlineData(2018, 7, 25, 8, 0, 0)]
        public void GetGeneration_ThirdGen_Success(int year, int month, int day, int hour, int minute, int second)
        {
            var createdDate = new DateTimeOffset(year, month, day, hour, minute, second, TimeSpan.Zero);

            var actual = BackupGenerationsHelper.GetGeneration(createdDate, _currentDate);

            actual.Should().Be(BackupGeneration.Third);
        } 
        
        [Theory]
        [InlineData(2019, 7, 26, 22, 0, 0)]
        [InlineData(1970, 1, 1, 0, 0, 0)]
        public void GetGeneration_ThirdGen_BoundedValues(int year, int month, int day, int hour, int minute, int second)
        {
            var createdDate = new DateTimeOffset(year, month, day, hour, minute, second, TimeSpan.Zero);

            var actual = BackupGenerationsHelper.GetGeneration(createdDate, _currentDate);

            actual.Should().Be(BackupGeneration.Third);
        } 
        
        [Theory]
        [InlineData(2019, 7, 26, 22, 0, 1)]
        [InlineData(2019, 8, 10, 20, 0, 0)]
        public void GetGeneration_ThirdGen_Fail(int year, int month, int day, int hour, int minute, int second)
        {
            var createdDate = new DateTimeOffset(year, month, day, hour, minute, second, TimeSpan.Zero);

            var actual = BackupGenerationsHelper.GetGeneration(createdDate, _currentDate);

            actual.Should().NotBe(BackupGeneration.Third);
        } 
        
        

        [Theory]
        [InlineData(2019, 8, 10, 22, 00, 1)]
        [InlineData(2019, 8, 12, 0, 0, 0)] 
        [InlineData(2019, 8, 11, 22, 00, 1)]
        [InlineData(2020, 1, 1, 0, 0, 0)]
        public void GetGeneration_Throw_ElapsedIsNegative(int year, int month, int day, int hour, int minute, int second)
        {
            var createdDate = new DateTimeOffset(year, month, day, hour, minute, second, TimeSpan.Zero);
            
            Func<BackupGeneration> act = () => BackupGenerationsHelper.GetGeneration(createdDate, _currentDate);

            act.Should().Throw<InvalidOperationException>().WithMessage("Elapsed can't be negative.");
        }
    }
}