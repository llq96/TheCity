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

        private CitizenData CitizenData => CreationData.CitizenData;
        private CitizenInbornData CitizenInbornData => CitizenData.CitizenInbornData;

        private CompanyData CompanyData => CreationData.CompanyData;

        public override void InstallBindings()
        {
            BindBaseCitizenData();
            BindFromCity();
            BindJobPost();
            BindComponentsFromHierarchy();
            BindMover();
            BindActivity();
        }

        private void BindBaseCitizenData()
        {
            Container.Bind<CitizenData>().FromInstance(CitizenData).AsSingle().NonLazy();
            Container.Bind<CitizenInbornData>().FromInstance(CitizenInbornData).AsSingle().NonLazy();
        }

        private void BindFromCity()
        {
            var _homeRoom = City.Rooms[CitizenInbornData.AddressIndex];
            Container.Bind<Room>().FromInstance(_homeRoom).AsSingle().NonLazy();

            var _company = City.Companies[CitizenInbornData.CompanyIndex];
            Container.Bind<Company>().FromInstance(_company).AsSingle().NonLazy();
        }

        private void BindJobPost()
        {
            var jobPost = CompanyData.JobPosts[CitizenInbornData.JobPostIndex];
            Container.Bind<JobPost>().FromInstance(jobPost).AsSingle().NonLazy();
        }

        private void BindComponentsFromHierarchy()
        {
            Container.Bind<Citizen>().FromComponentInHierarchy().AsSingle().NonLazy();
            Container.Bind<NavMeshAgent>().FromComponentInHierarchy().AsSingle().NonLazy();
        }

        private void BindMover()
        {
            Container.Bind<CitizenMover>().AsSingle().NonLazy();
        }

        private void BindActivity()
        {
            Container.BindInterfacesAndSelfTo<ScheduleCollection>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<CitizenActivityScheduler>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<CitizenActivityRunner>().AsSingle().NonLazy();
        }
    }
}