using JetBrains.Annotations;
using TheCity.Core;
using TheCity.Unity;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace TheCity.Installers
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
            ReBindFactoryParameters();
            BindBaseCitizenData();
            BindFromCity();
            BindJobPost();
            BindComponentsFromHierarchy();
            BindActivity();
            BindStatesSwitcher();
            BindCitizenAnimator();
            BindCitizenThinker();
        }


        private void ReBindFactoryParameters()
        {
            Container.Bind<City>().FromInstance(City).AsSingle().NonLazy();
            Container.Bind<CitizenCreationData>().FromInstance(CreationData).AsSingle().NonLazy();
        }

        private void BindBaseCitizenData()
        {
            Container.Bind<CitizenData>().FromInstance(CitizenData).AsSingle().NonLazy();
            Container.Bind<CitizenInbornData>().FromInstance(CitizenInbornData).AsSingle().NonLazy();
        }

        private void BindFromCity()
        {
            var _homeRoom = City.GetLivingRoom(CitizenInbornData.AddressData);
            Container.Bind<LivingRoom>().FromInstance(_homeRoom).AsSingle().NonLazy();

            var _homeRoomCitizenStuff = _homeRoom.CitizenStuffs[CitizenInbornData.HomeRoomStuffIndex];
            Container.Bind<HomeRoomCitizenStuff>().FromInstance(_homeRoomCitizenStuff).AsSingle().NonLazy();

            var _company = City.GetCompany(CompanyData);
            Container.Bind<Company>().FromInstance(_company).AsSingle().NonLazy();

            var _jobPlace = _company.Room.GetJobPlace(CitizenInbornData.JobPost);
            Container.Bind<JobPlace>().FromInstance(_jobPlace).AsSingle().NonLazy();
        }

        private void BindJobPost()
        {
            var jobPost = CitizenInbornData.JobPost;
            Container.Bind<JobPost>().FromInstance(jobPost).AsSingle().NonLazy();
        }

        private void BindComponentsFromHierarchy()
        {
            Container.Bind<Citizen>().FromComponentInHierarchy().AsSingle().NonLazy();
            Container.Bind<NavMeshAgent>().FromComponentInHierarchy().AsSingle().NonLazy();
            Container.Bind<Animator>().FromComponentInHierarchy().AsSingle().NonLazy();
        }

        private void BindActivity()
        {
            Container.BindInterfacesAndSelfTo<ScheduleCollection>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<CitizenActivityScheduler>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<CitizenActivityRunner>().AsSingle().NonLazy();
        }

        private void BindStatesSwitcher()
        {
            Container.BindInterfacesAndSelfTo<CitizenState_Moving>().FromSubContainerResolve().ByMethod(
                subContainer =>
                {
                    //State Dependencies Here...
                    subContainer.Bind<CitizenState_Moving>().AsSingle().NonLazy();
                }).AsSingle().NonLazy();

            Container.BindInterfacesAndSelfTo<CitizenState_Sleeping>().FromSubContainerResolve().ByMethod(
                subContainer =>
                {
                    //State Dependencies Here...
                    subContainer.Bind<CitizenState_Sleeping>().AsSingle().NonLazy();
                }).AsSingle().NonLazy();

            Container.BindInterfacesAndSelfTo<CitizenState_Working>().FromSubContainerResolve().ByMethod(
                subContainer =>
                {
                    //State Dependencies Here...
                    subContainer.Bind<CitizenState_Working>().AsSingle().NonLazy();
                }).AsSingle().NonLazy();


            Container.BindInterfacesAndSelfTo<CitizenStatesSwitcher>().AsSingle().NonLazy();
        }

        private void BindCitizenAnimator()
        {
            Container.BindInterfacesAndSelfTo<CitizenAnimator>().AsSingle().NonLazy();
        }

        private void BindCitizenThinker()
        {
            Container.Bind<CitizenThinker>().AsSingle().NonLazy();
        }
    }
}