using System.Collections;
using Zenject;
using NUnit.Framework;
using TheCity.InGameTime;
using TheCity.Tests.Utils;
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
            SetUp(GetCorrectInitialSettings());
        }

        private void SetUp(GameTimeInitialSettings gameTimeInitialSettings)
        {
            PreInstall();

            Container.Bind<GameTimeInitialSettings>().FromInstance(gameTimeInitialSettings).AsSingle().NonLazy();
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
        public IEnumerator GameTimeRun()
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
            var initialSettings = GetCorrectInitialSettings();
            initialSettings.Internal_StartDateTime.Internal_Year = wrongYear;

            Assert.Catch(() => SetUp(initialSettings));
        }

        [Test, TestCase(-1), TestCase(0), TestCase(13)]
        public void GameTime_WrongMonth(int wrongMonth)
        {
            var initialSettings = GetCorrectInitialSettings();
            initialSettings.Internal_StartDateTime.Internal_Month = wrongMonth;

            Assert.Catch(() => SetUp(initialSettings));
        }

        private GameTimeInitialSettings GetCorrectInitialSettings()
        {
            var initialSettings = ScriptableObject.CreateInstance<GameTimeInitialSettings>();

            var serializableDateTime = new SerializableDateTime();
            serializableDateTime.Internal_Year = 2000;
            serializableDateTime.Internal_Month = 1;
            serializableDateTime.Internal_Day = 1;

            initialSettings.Internal_StartDateTime = serializableDateTime;
            initialSettings.Internal_TimeSpeedMultiplier = 60f;

            return initialSettings;
        }
    }
}