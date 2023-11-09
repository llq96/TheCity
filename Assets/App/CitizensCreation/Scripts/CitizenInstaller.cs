using JetBrains.Annotations;
using Zenject;

namespace TheCity
{
    [UsedImplicitly]
    public class CitizenInstaller : Installer<CitizenInstaller>
    {
        [Inject] private CitizenCreationData CreationData { get; }

        public override void InstallBindings()
        {
            Container.Bind<CitizenData>().FromInstance(CreationData.CitizenData).AsSingle().NonLazy();
            Container.Bind<CitizenInbornData>().FromInstance(CreationData.CitizenData.CitizenInbornData)
                .AsSingle().NonLazy();


            BindComponentsFromHierarchy();
        }

        private void BindComponentsFromHierarchy()
        {
            Container.Bind<Citizen>().FromComponentInHierarchy().AsSingle().NonLazy();
        }
    }
}