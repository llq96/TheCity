using UnityEngine;
using Zenject;

namespace TheCity.InGameTime
{
    public class GameTimeInstaller : MonoInstaller
    {
        [SerializeField] private GameTimeInitialSettings _gameTimeInitialSettings;

        public override void InstallBindings()
        {
            Container.Bind<GameTimeInitialSettings>().FromInstance(_gameTimeInitialSettings).AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<GameTime>().AsSingle().NonLazy();
        }
    }
}