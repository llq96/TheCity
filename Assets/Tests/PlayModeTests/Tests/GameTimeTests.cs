using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace TheCity.Tests
{
    [TestFixture]
    public class GameTimeTests : BaseGameTimeTests
    {
        [Test]
        public void GameTime_ShouldExistAfterBind()
        {
            CorrectSetUp();
            Assert.NotNull(GameTime);
        }

        [UnityTest]
        public IEnumerator DateTime_ShouldIncreasingOverTime()
        {
            CorrectSetUp();

            var startDateTime = GameTime.GameDateTime;
            yield return new WaitForSeconds(0.1f);
            var dateTimeAfterDelay = GameTime.GameDateTime;
            bool dateTimeIncreased = startDateTime < dateTimeAfterDelay;

            Assert.That(dateTimeIncreased, $"DateTime was not increased after delay.");
        }
    }
}