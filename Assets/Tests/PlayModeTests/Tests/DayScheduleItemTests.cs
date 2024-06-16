using NUnit.Framework;

namespace TheCity.Tests
{
    [TestFixture]
    public class DayScheduleItemTests
    {
        [Test]
        public void Constructor_WhenCalled_SetPropertiesCorrect()
        {
            var timeOnly = CorrectThings.GetTimeOnly();
            var activity = CorrectThings.GetActivity();

            var dayScheduleItem = new DayScheduleItem(timeOnly, activity);

            Assert.AreEqual(timeOnly, dayScheduleItem.Time);
            Assert.AreEqual(activity, dayScheduleItem.Activity);
        }

        [Test]
        public void ToString_AfterConstructor_ReturnsNotEmpty()
        {
            var dayScheduleItem = CorrectThings.GetDayScheduleItem();

            Assert.IsNotEmpty(dayScheduleItem.ToString());
        }
    }
}