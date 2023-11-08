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
            Container.BindFactory<CitizenCreationData, Citizen, CitizenFactory>()
                .FromSubContainerResolve()
                .ByNewPrefabMethod(_citizenPrefab, InstallCitizen);
        }

        private void InstallCitizen(DiContainer subContainer, CitizenCreationData creationData)
        {
            subContainer.Bind<CitizenCreationData>().FromInstance(creationData);
            CitizenInstaller.Install(subContainer);
        }
    }

    [UsedImplicitly]
    public class CitizenFactory : PlaceholderFactory<CitizenCreationData, Citizen>
    {
    }
}