using JetBrains.Annotations;
using TheCity.CityDataGeneration;
using TheCity.Core;
using TheCity.Unity;
using UnityEngine;
using Zenject;

namespace TheCity.Installers
{
    public class CityFactoryInstaller : MonoInstaller
    {
        [SerializeField] private CityCreationSettings _cityCreationSettings;

        public override void InstallBindings()
        {
            InstallFactory();

            Container.Bind<CityStreetsDataGenerator>().AsSingle().NonLazy();
            Container.Bind<CityHousesDataGenerator>().AsSingle().NonLazy();
            Container.Bind<CityCompaniesDataGenerator>().AsSingle().NonLazy();
            Container.Bind<CityCitizensDataGenerator>().AsSingle().NonLazy();

            Container.Bind<CityDataGenerator>().AsSingle().NonLazy();


            Container.BindInterfacesAndSelfTo<CityCreator>().AsSingle().NonLazy();
        }

        private void InstallFactory()
        {
            Container.BindFactory<CityData, City, CityFactory>()
                .FromSubContainerResolve()
                .ByNewPrefabMethod(_cityCreationSettings.CityPrefab, CityFactoryInstallerMethod);
        }

        private void CityFactoryInstallerMethod(DiContainer subContainer, CityData cityData)
        {
            subContainer.Bind<CityData>().FromInstance(cityData);
            subContainer.Bind<CityCreationSettings>().FromInstance(_cityCreationSettings);
            CityInstaller.Install(subContainer);
        }
    }

    [UsedImplicitly]
    public class CityFactory : PlaceholderFactory<CityData, City>
    {
    }
}