using NUnit.Framework;

namespace TheCity.Tests
{
    public class ActivityTests
    {
        [Test]
        public void CorrectToString()
        {
            var activity = new Activity();
            Assert.IsNotEmpty(activity.ToString());
        }
    }
}