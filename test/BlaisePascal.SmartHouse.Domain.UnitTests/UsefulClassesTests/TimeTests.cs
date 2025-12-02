using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.UsefulClasses;

namespace BlaisePascal.SmartHouse.Domain.UnitTests.UsefulClassesTests
{
    public class TimeTests
    {
        //Hours
        [Fact]
        public void Constructor_HoursAreCorrect()
        {
            int hour = 22;
            var time = new Time(hour, 35, 4);
            Assert.Equal(hour,time.Hours);
        }

        [Fact]
        public void Constructor_HoursMinorThanZero()
        {
            int hour = -1;
            var time = new Time(hour, 35, 4);
            Assert.NotEqual(hour,time.Hours);
        }

        [Fact]
        public void Constructor_HoursMoreThanTwentyThree()
        {
            int hour = 24;
            var time = new Time(hour, 35, 4);
            Assert.NotEqual(hour,time.Hours);
        }

        //Minutes
        [Fact]
        public void Constructor_MinutesAreCorrect()
        {
            int minutes = 22;
            var time = new Time(5, minutes, 4);
            Assert.Equal(minutes, time.Minutes);

        }
        [Fact]
        public void Constructor_MinutesMinorThanZero()
        {
            int minutes = -1;
            var time = new Time(5,minutes, 4);
            Assert.NotEqual(minutes, time.Minutes);
        }

        [Fact]
        public void Constructor_MinutesMoreThanFifthyNine()
        {
            int minutes = 60;
            var time = new Time(5, minutes, 4);
            Assert.NotEqual(minutes, time.Minutes);
        }

        //Seconds
        [Fact]
        public void Constructor_SecondsAreCorrect()
        {
            int seconds = 22;
            var time = new Time(5, 6, seconds);
            Assert.Equal(seconds, time.Seconds);
        }
        [Fact]
        public void Constructor_SecondsMinorThanZero()
        {
            int seconds = -1;
            var time = new Time(5, 35, seconds);
            Assert.NotEqual(seconds, time.Seconds);
        }
        [Fact]
        public void Constructor_SecondsMoreThanFifthyNine()
        {
            int seconds = 60;
            var time = new Time(5, 5,seconds);
            Assert.NotEqual(seconds, time.Seconds);
        }

    }
}
