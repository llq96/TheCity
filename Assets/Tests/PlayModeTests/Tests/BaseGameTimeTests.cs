using TheCity.Unity;
using Zenject;

namespace TheCity.Tests.GameTimeTests
{
    public abstract class BaseGameTimeTests : ZenjectEmptyContextsUnitTestFixture
    {
        [Inject] protected GameTime GameTime { get; }

        protected void CorrectSetUp()
        {
            SetUp(CorrectThings.GetIGameTimeInitialSettings());
        }

        protected void SetUp(IGameTimeInitialSettings gameTimeInitialSettings)
        {
            PreInstall();

            Container.Bind<IGameTimeInitialSettings>().FromInstance(gameTimeInitialSettings).AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<GameTime>().AsSingle().NonLazy();

            PostInstall();
        }
    }
}