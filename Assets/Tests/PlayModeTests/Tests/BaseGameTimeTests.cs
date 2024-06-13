using System;
using Moq;
using Zenject;
using TheCity.InGameTime;

namespace TheCity.Tests
{
    public abstract class BaseGameTimeTests : ZenjectEmptyContextsUnitTestFixture
    {
        [Inject]
        protected GameTime GameTime { get; }

        protected void CorrectSetUp()
        {
            SetUp(GetCorrectInitialSettingsMock().Object);
        }

        protected void SetUp(IGameTimeInitialSettings gameTimeInitialSettings)
        {
            PreInstall();

            Container.Bind<IGameTimeInitialSettings>().FromInstance(gameTimeInitialSettings).AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<GameTime>().AsSingle().NonLazy();

            PostInstall();
        }

        protected static Mock<IGameTimeInitialSettings> GetCorrectInitialSettingsMock()
        {
            var mock = new Mock<IGameTimeInitialSettings>();
            mock.Setup(x => x.StartDateTime).Returns(new DateTime(2000, 1, 1, 0, 0, 0));
            mock.Setup(x => x.TimeSpeedMultiplier).Returns(60f);
            return mock;
        }
    }
}