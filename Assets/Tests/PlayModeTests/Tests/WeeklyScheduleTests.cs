using TheCity.Core;
using NUnit.Framework;
using System;

namespace TheCity.Tests
{
    [TestFixture]
    public class WeeklyScheduleTests
    {
        [Test]
        public void Constructor_WhenCalled_ShouldHaveSevenDaySchedules()
        {
            var weeklySchedule = new WeeklySchedule();

            Assert.IsNotNull(weeklySchedule.SundaySchedule);
            Assert.IsNotNull(weeklySchedule.MondaySchedule);
            Assert.IsNotNull(weeklySchedule.TuesdaySchedule);
            Assert.IsNotNull(weeklySchedule.WednesdaySchedule);
            Assert.IsNotNull(weeklySchedule.ThursdaySchedule);
            Assert.IsNotNull(weeklySchedule.FridaySchedule);
            Assert.IsNotNull(weeklySchedule.SaturdaySchedule);
        }

        [Test]
        public void GetDaySchedule_WhenCalledWithSpecificDay_ReturnsCorrectDaySchedule()
        {
            var weeklySchedule = CorrectThings.GetWeeklySchedule();

            var sundaySchedule = weeklySchedule.GetDaySchedule(DayOfWeek.Sunday);
            var mondaySchedule = weeklySchedule.GetDaySchedule(DayOfWeek.Monday);

            Assert.AreEqual(weeklySchedule.SundaySchedule, sundaySchedule);
            Assert.AreEqual(weeklySchedule.MondaySchedule, mondaySchedule);
        }

        [Test]
        public void ToString_AfterInitialization_ReturnsNonEmptyString()
        {
            var weeklySchedule = CorrectThings.GetWeeklySchedule();

            Assert.IsNotEmpty(weeklySchedule.ToString());
        }
    }
}