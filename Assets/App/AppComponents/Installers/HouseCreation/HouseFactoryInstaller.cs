using JetBrains.Annotations;
using TheCity.Core;
using TheCity.Unity;
using UnityEngine;
using Zenject;

namespace TheCity.Installers
{
    public class HouseFactoryInstaller : MonoInstaller
    {
        [SerializeField] private CityCreationSettings _cityCreationSettings;

        public override void InstallBindings()
        {
            InstallFactory();
        }

        private void InstallFactory()
        {
            Container.BindFactory<HouseData, House, HouseFactory>()
                .FromSubContainerResolve()
                .ByNewPrefabMethod(_cityCreationSettings.HousePrefab, CityFactoryInstallerMethod);
        }

        private void CityFactoryInstallerMethod(DiContainer subContainer, HouseData houseData)
        {
            subContainer.Bind<HouseData>().FromInstance(houseData);
            subContainer.Bind<CityCreationSettings>().FromInstance(_cityCreationSettings);
            HouseInstaller.Install(subContainer);
        }
    }

    [UsedImplicitly]
    public class HouseFactory : PlaceholderFactory<HouseData, House>
    {
    }
}