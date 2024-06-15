using System;
using NUnit.Framework;

namespace TheCity.Tests
{
    public class TimeOnlyTests
    {
        private static readonly int[] WrongHours = { -1, 24, 25, 100 };
        private static readonly int[] WrongMinutes = { -1, 60, 61, 100 };

        [Test]
        public void AllPossibleCorrectTimeCheck()
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
        public void Correct_ToString_1SymbolHour_1SymbolMinute()
        {
            var timeOnly = new TimeOnly(5, 5);
            var str = timeOnly.ToString();
            Assert.AreEqual(str, "05:05");
        }

        [Test]
        public void Correct_ToString_1SymbolHour_2SymbolMinute()
        {
            var timeOnly = new TimeOnly(5, 11);
            var str = timeOnly.ToString();
            Assert.AreEqual(str, "05:11");
        }

        [Test]
        public void Correct_ToString_2SymbolHour_1SymbolMinute()
        {
            var timeOnly = new TimeOnly(11, 5);
            var str = timeOnly.ToString();
            Assert.AreEqual(str, "11:05");
        }

        [Test]
        public void Correct_ToString_2SymbolHour_2SymbolMinute()
        {
            var timeOnly = new TimeOnly(11, 11);
            var str = timeOnly.ToString();
            Assert.AreEqual(str, "11:11");
        }

        [Test, TestCaseSource(nameof(WrongHours))]
        public void ThrowWhen_WrongInput_Hour(int hour)
        {
            Assert.Catch(typeof(ArgumentException),
                () =>
                {
                    var timeOnly = new TimeOnly(hour, 30);
                });
        }

        [Test, TestCaseSource(nameof(WrongMinutes))]
        public void ThrowWhen_WrongInput_Minute(int minute)
        {
            Assert.Catch(typeof(ArgumentException),
                () =>
                {
                    var timeOnly = new TimeOnly(12, minute);
                });
        }
    }
}