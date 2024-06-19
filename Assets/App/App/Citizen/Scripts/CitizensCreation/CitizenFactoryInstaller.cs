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
                .ByNewPrefabInstaller<CitizenInstaller>(_citizenPrefab);
        }
    }

    [UsedImplicitly]
    public class CitizenFactory : PlaceholderFactory<City, CitizenCreationData, Citizen>
    {
    }
}