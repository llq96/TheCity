using JetBrains.Annotations;
using TheCity.Unity;
using UnityEngine;
using Zenject;

namespace TheCity.Installers
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