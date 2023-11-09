using JetBrains.Annotations;
using UnityEngine;
using Zenject;

namespace TheCity
{
    public class CitizenFactoryInstaller : MonoInstaller
    {
        [SerializeField] private GameObject _citizenPrefab;

        public override void InstallBindings()
        {
            InstallFactory();

            Container.BindInterfacesAndSelfTo<CitizensCreator>().AsSingle().NonLazy();
        }

        private void InstallFactory()
        {
            Container.BindFactory<City, CitizenCreationData, Citizen, CitizenFactory>()
                .FromSubContainerResolve()
                .ByNewPrefabMethod(_citizenPrefab, InstallCitizen);
        }

        private void InstallCitizen(DiContainer subContainer, City city, CitizenCreationData creationData)
        {
            subContainer.Bind<City>().FromInstance(city);
            subContainer.Bind<CitizenCreationData>().FromInstance(creationData);
            CitizenInstaller.Install(subContainer);
        }
    }

    [UsedImplicitly]
    public class CitizenFactory : PlaceholderFactory<City, CitizenCreationData, Citizen>
    {
    }
}