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
            //TODO Можно разбить по другому на методы
            BindBaseCitizenData();
            BindComponentsFromHierarchy();
            BindNewComponents();
            BindOther();
        }

        private void BindBaseCitizenData()
        {
            var citizenData = CreationData.CitizenData;
            Container.Bind<CitizenData>().FromInstance(citizenData).AsSingle().NonLazy();

            var citizenInbornData = citizenData.CitizenInbornData;
            Container.Bind<CitizenInbornData>().FromInstance(citizenInbornData).AsSingle().NonLazy();

            var room = City.Rooms[citizenInbornData.AddressIndex];
            Container.Bind<Room>().FromInstance(room).AsSingle().NonLazy();

            var company = City.Companies[citizenInbornData.CompanyIndex];
            Container.Bind<Company>().FromInstance(company).AsSingle().NonLazy();

            var jobPost = company.JobPosts[citizenInbornData.JobPostIndex];
            Container.Bind<JobPost>().FromInstance(jobPost).AsSingle().NonLazy();
        }

        private void BindComponentsFromHierarchy()
        {
            Container.Bind<Citizen>().FromComponentInHierarchy().AsSingle().NonLazy();
            Container.Bind<NavMeshAgent>().FromComponentInHierarchy().AsSingle().NonLazy();
        }

        private void BindNewComponents()
        {
            Container.Bind<CitizenMover>().FromNewComponentOnRoot().AsSingle().NonLazy();
        }

        private void BindOther()
        {
            Container.BindInterfacesAndSelfTo<CitizenActivityScheduler>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<CitizenActivityRunner>().AsSingle().NonLazy();
        }
    }
}