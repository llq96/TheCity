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
            Container.Bind<CitizenInbornData>().FromInstance(CreationData.CitizenInbornData);

            BindComponentsFromHierarchy();
        }

        private void BindComponentsFromHierarchy()
        {
            Container.Bind<Citizen>().FromComponentInHierarchy().AsSingle().NonLazy();
        }
    }
}