using JetBrains.Annotations;
using TheCity.Core;
using TheCity.Unity;
using Zenject;

namespace TheCity.Installers
{
    [UsedImplicitly]
    public class CityInstaller : Installer<CityInstaller>
    {
        [Inject] private CityData CityData { get; }

        public override void InstallBindings()
        {
            ReBindFactoryParameters();

            BindComponentsFromHierarchy();
        }

        private void ReBindFactoryParameters()
        {
            Container.Bind<CityData>().FromInstance(CityData).AsSingle().NonLazy();
        }

        private void BindComponentsFromHierarchy()
        {
            Container.Bind<City>().FromComponentInHierarchy().AsSingle().NonLazy();
        }
    }
}