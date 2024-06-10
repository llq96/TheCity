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
            var citizenData = CreationData.CitizenData;
            var citizenInbornData = citizenData.CitizenInbornData;

            Container.Bind<CitizenData>().FromInstance(citizenData).AsSingle().NonLazy();
            Container.Bind<CitizenInbornData>().FromInstance(citizenInbornData).AsSingle().NonLazy();


            var room = City.Rooms[citizenInbornData.AddressIndex];
            Container.Bind<Room>().FromInstance(room).AsSingle().NonLazy();

            var company = City.Companies[citizenInbornData.CompanyIndex];
            Container.Bind<Company>().FromInstance(company).AsSingle().NonLazy();

            Container.Bind<JobPost>()
                .FromInstance(company.JobPosts[citizenInbornData.JobPostIndex]).AsSingle()
                .NonLazy();

            BindComponentsFromHierarchy();
        }

        private void BindComponentsFromHierarchy()
        {
            Container.Bind<Citizen>().FromComponentInHierarchy().AsSingle().NonLazy();
            Container.Bind<NavMeshAgent>().FromComponentInHierarchy().AsSingle().NonLazy();
        }
    }
}