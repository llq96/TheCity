using JetBrains.Annotations;
using UnityEngine;
using Zenject;

namespace TheCity
{
    public class CityFactoryInstaller : MonoInstaller
    {
        [SerializeField] private GameObject _cityPrefab;

        public override void InstallBindings()
        {
            InstallFactory();

            Container.Bind<CityDataGenerator>().AsSingle().Lazy(); //TODO

            Container.BindInterfacesAndSelfTo<CityCreator>().AsSingle().NonLazy();
        }

        private void InstallFactory()
        {
            Container.BindFactory<CityData, City, CityFactory>()
                .FromSubContainerResolve()
                .ByNewPrefabMethod(_cityPrefab, InstallCity);
        }

        private void InstallCity(DiContainer subContainer, CityData cityData)
        {
            subContainer.Bind<CityData>().FromInstance(cityData);
            CityInstaller.Install(subContainer);
        }
    }

    [UsedImplicitly]
    public class CityFactory : PlaceholderFactory<CityData, City>
    {
    }
}