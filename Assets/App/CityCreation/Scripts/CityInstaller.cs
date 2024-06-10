using JetBrains.Annotations;
using Zenject;

namespace TheCity
{
    [UsedImplicitly]
    public class CityInstaller : Installer<CityInstaller>
    {
        [Inject] private CityData CityData { get; }

        public override void InstallBindings()
        {
            BindComponentsFromHierarchy();
        }

        private void BindComponentsFromHierarchy()
        {
            Container.Bind<City>().FromComponentInHierarchy().AsSingle().NonLazy();
            var city = Container.Resolve<City>();
            for (int i = 0; i < city.Rooms.Count; i++)
            {
                city.Rooms[i].Construct(CityData.AddressesDataList[i]);
            }
        }
    }
}