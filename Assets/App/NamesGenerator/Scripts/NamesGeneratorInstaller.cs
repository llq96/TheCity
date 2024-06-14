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
            Container.Bind<NamesGeneratorSettings>().FromInstance(_namesGeneratorSettings).AsSingle().NonLazy();

            Container.BindFactory<NamesGenerator, NamesGeneratorFactory>().FromSubContainerResolve().ByMethod(
                InstallerMethod);
            // Container.BindInterfacesAndSelfTo<NamesGenerator>().AsTransient().NonLazy();
        }

        private void InstallerMethod(DiContainer container)
        {
            container.Bind<NamesGeneratorSettings>().FromInstance(_namesGeneratorSettings).AsSingle().NonLazy();
            container.BindInterfacesAndSelfTo<NamesGenerator>().AsSingle().NonLazy();
        }

        [UsedImplicitly]
        public class NamesGeneratorFactory : PlaceholderFactory<NamesGenerator>
        {
        }
    }
}