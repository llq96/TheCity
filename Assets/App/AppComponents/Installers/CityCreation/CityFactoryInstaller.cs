using JetBrains.Annotations;
using UnityEngine;
using Zenject;

namespace TheCity.CityGeneration.Installer
{
    public class CityFactoryInstaller : MonoInstaller
    {
        [SerializeField] private GameObject _cityPrefab;

        public override void InstallBindings()
        {
            InstallFactory();

            Container.Bind<CityAddressesDataGenerator>().AsSingle().NonLazy();
            Container.Bind<CityCompaniesDataGenerator>().AsSingle().NonLazy();
            Container.Bind<CityCitizensDataGenerator>().AsSingle().NonLazy();

            Container.Bind<CityDataGenerator>().AsSingle().NonLazy();


            Container.BindInterfacesAndSelfTo<CityCreator>().AsSingle().NonLazy();
        }

        private void InstallFactory()
        {
            Container.BindFactory<CityData, City, CityFactory>()
                .FromSubContainerResolve()
                .ByNewPrefabInstaller<CityInstaller>(_cityPrefab);
        }
    }

    [UsedImplicitly]
    public class CityFactory : PlaceholderFactory<CityData, City>
    {
    }
}