using JetBrains.Annotations;
using Zenject;

namespace TheCity
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