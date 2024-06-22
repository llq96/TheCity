using TheCity.CityDataGeneration;
using UnityEngine;
using Zenject;

namespace TheCity.Installers
{
    public class NamesGeneratorInstaller : MonoInstaller
    {
        [SerializeField] private NamesGeneratorSettings _namesGeneratorSettings;

        public override void InstallBindings()
        {
            Container.Bind<INamesGeneratorSettings>().FromInstance(_namesGeneratorSettings).AsSingle().NonLazy();

            Container.Bind<ICitizenNamesGenerator>().To<CitizenNamesGenerator>().AsSingle().NonLazy();
            Container.Bind<IStreetNamesGenerator>().To<StreetNamesGenerator>().AsSingle().NonLazy();
            Container.Bind<ICompanyNamesGenerator>().To<CompanyNamesGenerator>().AsSingle().NonLazy();
        }
    }
}