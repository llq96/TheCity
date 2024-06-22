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

            var room = City.GetWorkRoom(CompanyData.AddressIndex);
            Container.Bind<WorkRoom>().FromInstance(room).AsSingle().NonLazy();
            Container.Bind<List<JobPost>>().FromInstance(CompanyData.JobPosts).AsSingle().NonLazy();

            Container.Bind<Company>().FromComponentInHierarchy().AsSingle().NonLazy();
        }

        private void ReBindFactoryParameters()
        {
            Container.Bind<City>().FromInstance(City).AsSingle().NonLazy();
            Container.Bind<CompanyData>().FromInstance(CompanyData).AsSingle().NonLazy();
        }
    }
}