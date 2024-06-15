using JetBrains.Annotations;
using UnityEngine;
using Zenject;

namespace TheCity
{
    public class NamesGeneratorInstaller : MonoInstaller
    {
        [SerializeField] private NamesGeneratorSettings _namesGeneratorSettings;

        public override void InstallBindings()
        {
            Container.BindFactory<NamesGenerator, NamesGeneratorFactory>()
                .FromSubContainerResolve()
                .ByMethod(InstallerMethod);
        }

        private void InstallerMethod(DiContainer subContainer)
        {
            subContainer.Bind<INamesGeneratorSettings>().FromInstance(_namesGeneratorSettings).AsSingle().NonLazy();

            subContainer.Bind<CitizenNamesGenerator>().AsSingle().NonLazy();
            subContainer.Bind<StreetNamesGenerator>().AsSingle().NonLazy();
            subContainer.Bind<CompanyNamesGenerator>().AsSingle().NonLazy();

            subContainer.BindInterfacesAndSelfTo<NamesGenerator>().AsSingle().NonLazy();
        }

        [UsedImplicitly]
        public class NamesGeneratorFactory : PlaceholderFactory<NamesGenerator>
        {
        }
    }
}