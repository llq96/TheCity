using NUnit.Framework;

namespace TheCity.Tests
{
    [TestFixture]
    public class ScheduleActivityTests
    {
        [Test]
        public void Constructor_WhenCalled_SetPropertiesCorrect()
        {
            var dateTime = CorrectThings.GetDateTime();
            var activity = CorrectThings.GetActivity();

            var scheduleActivity = new ScheduleActivity(dateTime, activity);

            Assert.AreEqual(dateTime, scheduleActivity.DateTime);
            Assert.AreEqual(activity, scheduleActivity.Activity);
        }

        [Test]
        public void ToString_AfterConstructor_ReturnsNotEmpty()
        {
            var scheduleActivity = CorrectThings.GetScheduleActivity();
            Assert.IsNotEmpty(scheduleActivity.ToString());
        }
    }
}