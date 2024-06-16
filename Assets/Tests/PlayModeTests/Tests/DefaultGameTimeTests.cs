using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace TheCity.Tests.GameTimeTests
{
    [TestFixture]
    public class DefaultGameTimeTests : BaseGameTimeTests
    {
        [Test]
        public void ResolvedGameTime_AfterCorrectSetUp_NotNull()
        {
            CorrectSetUp();

            Assert.NotNull(GameTime);
        }

        [UnityTest]
        public IEnumerator GameDateTime_AfterDelay_ShouldIncreased()
        {
            CorrectSetUp();
            var startDateTime = GameTime.GameDateTime;

            yield return new WaitForSeconds(0.1f);

            Assert.GreaterOrEqual(GameTime.GameDateTime, startDateTime, "DateTime was not increased after delay.");
        }
    }
}