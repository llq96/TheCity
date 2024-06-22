using JetBrains.Annotations;
using TheCity.Unity;
using Zenject;

namespace TheCity.Installers
{
    [UsedImplicitly]
    public class PlayerInstaller : Installer<PlayerInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<Player>().FromComponentInHierarchy().AsSingle().NonLazy();
        }
    }
}