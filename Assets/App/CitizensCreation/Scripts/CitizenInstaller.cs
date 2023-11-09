using JetBrains.Annotations;
using UnityEngine.AI;
using Zenject;

namespace TheCity
{
    [UsedImplicitly]
    public class CitizenInstaller : Installer<CitizenInstaller>
    {
        [Inject] private City City { get; }
        [Inject] private CitizenCreationData CreationData { get; }

        public override void InstallBindings()
        {
            var room = City.Rooms[CreationData.CitizenData.CitizenInbornData.AddressIndex];
            Container.Bind<Room>().FromInstance(room).AsSingle().NonLazy();

            var company = City.Companies[CreationData.CitizenData.CitizenInbornData.CompanyIndex];
            Container.Bind<Company>().FromInstance(company).AsSingle().NonLazy();

            Container.Bind<CitizenData>().FromInstance(CreationData.CitizenData).AsSingle().NonLazy();
            Container.Bind<CitizenInbornData>().FromInstance(CreationData.CitizenData.CitizenInbornData)
                .AsSingle().NonLazy();


            BindComponentsFromHierarchy();
        }

        private void BindComponentsFromHierarchy()
        {
            Container.Bind<Citizen>().FromComponentInHierarchy().AsSingle().NonLazy();
            Container.Bind<NavMeshAgent>().FromComponentInHierarchy().AsSingle().NonLazy();
        }
    }
}