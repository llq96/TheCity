using System;
using NUnit.Framework;

namespace TheCity.Tests
{
    public class TimeOnlyTests
    {
        private static readonly int[] WrongHours = { -1, 24, 25, 100 };
        private static readonly int[] WrongMinutes = { -1, 60, 61, 100 };

        [Test]
        public void Properties_AfterAllCorrectSetUps_Correct()
        {
            for (int hour = 0; hour < 24; hour++)
            {
                for (int minute = 0; minute < 60; minute++)
                {
                    var timeOnly = new TimeOnly(hour, minute);
                    Assert.AreEqual(hour, timeOnly.Hour);
                    Assert.AreEqual(minute, timeOnly.Minute);
                }
            }
        }

        [Test]
        public void ToString_1SymbolHourAnd1SymbolMinute_CorrectString()
        {
            var timeOnly = new TimeOnly(5, 5);
            var str = timeOnly.ToString();
            Assert.AreEqual("05:05", str);
        }

        [Test]
        public void ToString_1SymbolHourAnd2SymbolMinute_CorrectString()
        {
            var timeOnly = new TimeOnly(5, 11);
            var str = timeOnly.ToString();
            Assert.AreEqual("05:11", str);
        }

        [Test]
        public void ToString_2SymbolHourAnd1SymbolMinute_CorrectString()
        {
            var timeOnly = new TimeOnly(11, 5);
            var str = timeOnly.ToString();
            Assert.AreEqual("11:05", str);
        }

        [Test]
        public void ToString_2SymbolHourAnd2SymbolMinute_CorrectString()
        {
            var timeOnly = new TimeOnly(11, 11);
            var str = timeOnly.ToString();
            Assert.AreEqual("11:11", str);
        }

        [Test, TestCaseSource(nameof(WrongHours))]
        public void Constructor_WhenWrongHour_Throw(int hour)
        {
            Assert.Catch(typeof(ArgumentException),
                () =>
                {
                    var timeOnly = new TimeOnly(hour, 30);
                });
        }

        [Test, TestCaseSource(nameof(WrongMinutes))]
        public void Constructor_WhenWrongMinute_Throw(int minute)
        {
            Assert.Catch(typeof(ArgumentException),
                () =>
                {
                    var timeOnly = new TimeOnly(12, minute);
                });
        }
    }
}