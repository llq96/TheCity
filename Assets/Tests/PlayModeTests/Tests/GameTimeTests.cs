using System;
using System.Collections;
using Moq;
using Zenject;
using NUnit.Framework;
using TheCity.InGameTime;
using UnityEngine;
using UnityEngine.TestTools;

namespace TheCity.Tests
{
    [TestFixture]
    public class GameTimeTests : ZenjectEmptyContextsUnitTestFixture
    {
        [Inject] private GameTime GameTime { get; }

        private void CorrectSetUp()
        {
            SetUp(GetCorrectInitialSettingsMock().Object);
        }

        private void SetUp(IGameTimeInitialSettings gameTimeInitialSettings)
        {
            PreInstall();

            Container.Bind<IGameTimeInitialSettings>().FromInstance(gameTimeInitialSettings).AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<GameTime>().AsSingle().NonLazy();

            PostInstall();
        }

        [Test]
        public void GameTimeNotNull()
        {
            CorrectSetUp();
            Assert.NotNull(GameTime);
        }

        [UnityTest]
        public IEnumerator DateTimeIncreasingOverTime()
        {
            CorrectSetUp();

            var gameDateTime = GameTime.GameDateTime;
            yield return new WaitForSeconds(2.1f);
            var gameTimeAfterDelay = GameTime.GameDateTime;
            bool isMoreThanWas = gameDateTime < gameTimeAfterDelay;

            Assert.That(isMoreThanWas, $"{gameDateTime} {gameTimeAfterDelay}");
        }

        [Test, TestCase(-1), TestCase(0), TestCase(10001)]
        public void GameTime_WrongYear(int wrongYear)
        {
            var initialSettingsMock = GetCorrectInitialSettingsMock();
            initialSettingsMock.Setup(x => x.StartDateTime).Returns(() => new DateTime(wrongYear, 1, 1));

            Assert.Catch(() => SetUp(initialSettingsMock.Object));
        }

        [Test, TestCase(-1), TestCase(0), TestCase(13)]
        public void GameTime_WrongMonth(int wrongMonth)
        {
            var initialSettingsMock = GetCorrectInitialSettingsMock();
            initialSettingsMock.Setup(x => x.StartDateTime).Returns(() => new DateTime(2000, wrongMonth, 1));

            Assert.Catch(() => SetUp(initialSettingsMock.Object));
        }

        private Mock<IGameTimeInitialSettings> GetCorrectInitialSettingsMock()
        {
            var mock = new Mock<IGameTimeInitialSettings>();
            mock.Setup(x => x.StartDateTime).Returns(new DateTime(2000, 1, 1, 0, 0, 0));
            mock.Setup(x => x.TimeSpeedMultiplier).Returns(60f);
            return mock;
        }
    }
}