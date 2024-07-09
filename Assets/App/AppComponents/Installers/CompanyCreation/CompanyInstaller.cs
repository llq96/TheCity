using System.Collections.Generic;
using JetBrains.Annotations;
using TheCity.Core;
using TheCity.Unity;
using Zenject;

namespace TheCity.Installers
{
    [UsedImplicitly]
    public class CompanyInstaller : Installer<CompanyInstaller>
    {
        [Inject] private City City { get; }
        [Inject] private CompanyData CompanyData { get; }


        public override void InstallBindings()
        {
            ReBindFactoryParameters();

            var room = City.GetWorkRoom(CompanyData.AddressData);
            Container.Bind<WorkRoom>().FromInstance(room).AsSingle().NonLazy();
            Container.Bind<List<JobPost>>().FromInstance(CompanyData.JobPosts).AsSingle().NonLazy();

            Container.Bind<Company>().FromComponentInHierarchy().AsSingle().NonLazy();

            BindJobPlaces(room);
        }

        private void ReBindFactoryParameters()
        {
            Container.Bind<City>().FromInstance(City).AsSingle().NonLazy();
            Container.Bind<CompanyData>().FromInstance(CompanyData).AsSingle().NonLazy();
        }

        private void BindJobPlaces(WorkRoom workRoom)
        {
            for (int i = 0; i < CompanyData.JobPosts.Count; i++)
            {
                var jobPost = CompanyData.JobPosts[i];
                var jobPlace = workRoom.JobPlaces[i];

                var subContainer = Container.CreateSubContainer();
                subContainer.Bind<JobPost>().FromInstance(jobPost);
                subContainer.InjectGameObject(jobPlace.gameObject);
            }
        }
    }
}