using System.Collections;
using Zenject;
using NUnit.Framework;
using TheCity;
using TheCity.InGameTime;
using UnityEngine;
using UnityEngine.TestTools;

[TestFixture]
public class GameTimeTests : ZenjectEmptyContextsUnitTestFixture
{
    [Inject] private GameTime GameTime { get; }

    [SetUp]
    public void CommonInstall()
    {
        PreInstall();

        var gameTimeInstaller = ProjectContextAccessor.GetProjectContextComponent<GameTimeInstaller>();
        var gameTimeInitialSettings = gameTimeInstaller.GameTimeInitialSettings;

        Container.Bind<GameTimeInitialSettings>().FromInstance(gameTimeInitialSettings).AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<GameTime>().AsSingle().NonLazy();

        PostInstall();
    }

    [Test]
    public void GameTimeNotNull()
    {
        Assert.NotNull(GameTime);
    }

    [UnityTest]
    public IEnumerator GameTimeRun()
    {
        var gameDateTime = GameTime.GameDateTime;
        yield return new WaitForSeconds(2.1f);
        var gameTimeAfterDelay = GameTime.GameDateTime;
        bool isMoreThanWas = gameDateTime < gameTimeAfterDelay;
        Assert.That(isMoreThanWas, $"{gameDateTime} {gameTimeAfterDelay}");
    }
}