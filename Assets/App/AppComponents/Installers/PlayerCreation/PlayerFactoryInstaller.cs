using JetBrains.Annotations;
using TheCity.Unity;
using UnityEngine;
using Zenject;

namespace TheCity.Installers
{
    public class PlayerFactoryInstaller : MonoInstaller
    {
        [SerializeField] private GameObject _playerPrefab;

        public override void InstallBindings()
        {
            InstallFactory();

            Container.BindInterfacesAndSelfTo<PlayerCreator>().AsSingle().NonLazy();
        }

        private void InstallFactory()
        {
            Container.BindFactory<Player, PlayerFactory>()
                .FromSubContainerResolve()
                .ByNewPrefabInstaller<PlayerInstaller>(_playerPrefab);
        }

        [UsedImplicitly]
        public class PlayerFactory : PlaceholderFactory<Player>
        {
        }
    }
}