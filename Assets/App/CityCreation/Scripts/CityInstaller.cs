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
            Container.Bind<CityData>().FromInstance(CityData).AsSingle().NonLazy();

            BindComponentsFromHierarchy();
        }

        private void BindComponentsFromHierarchy()
        {
            Container.Bind<City>().FromComponentInHierarchy().AsSingle().NonLazy();
        }
    }
}