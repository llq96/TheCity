using JetBrains.Annotations;
using Zenject;

namespace TheCity
{
    [UsedImplicitly]
    public class CompanyInstaller : Installer<CompanyInstaller>
    {
        [Inject] private City City { get; }
        [Inject] private CompanyData CompanyData { get; }


        public override void InstallBindings()
        {
            var room = City.Rooms[CompanyData.AddressIndex];
            Container.Bind<Room>().FromInstance(room).AsSingle().NonLazy();
            Container.Bind<Company>().FromComponentInHierarchy().AsSingle().NonLazy();
        }
    }
}