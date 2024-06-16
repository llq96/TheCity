using NUnit.Framework;

namespace TheCity.Tests
{
    public class ActivityTests
    {
        [Test]
        public void ToString_AfterConstructor_ReturnsNotEmpty()
        {
            var activity = new Activity();
            Assert.IsNotEmpty(activity.ToString());
        }
    }
}