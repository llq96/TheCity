using TheCity.Unity;
using UnityEngine;
using Zenject;

namespace TheCity.Installers
{
    public class GameTimeInstaller : MonoInstaller
    {
        [SerializeField] private GameTimeInitialSettings _gameTimeInitialSettings;

        public override void InstallBindings()
        {
            Container.Bind<IGameTimeInitialSettings>().FromInstance(_gameTimeInitialSettings).AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<GameTime>().AsSingle().NonLazy();
        }
    }
}