using NUnit.Framework;

namespace TheCity.Tests
{
    public class ActivityTests
    {
        [Test]
        public void ToString_NotEmpty()
        {
            var activity = new Activity();
            Assert.IsNotEmpty(activity.ToString());
        }
    }
}