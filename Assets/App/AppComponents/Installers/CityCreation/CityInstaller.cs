using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using TheCity.Core;
using TheCity.Unity;
using Zenject;
using Object = UnityEngine.Object;

namespace TheCity.Installers
{
    [UsedImplicitly]
    public class CityInstaller : Installer<CityInstaller>
    {
        [Inject] private CityData CityData { get; }
        [Inject] private HouseFactory HouseFactory { get; }

        public override void InstallBindings()
        {
            ReBindFactoryParameters();
            BindComponentsFromHierarchy();

            GenerateHouses();
        }

        private void ReBindFactoryParameters()
        {
            Container.Bind<CityData>().FromInstance(CityData).AsSingle().NonLazy();
        }
        
        private void BindComponentsFromHierarchy()
        {
            Container.Bind<City>().FromComponentInHierarchy().AsSingle().NonLazy();
        }

        private void GenerateHouses()
        {
            var city = Container.Resolve<City>();

            List<House> houses = new();

            for (var houseIndex = 0; houseIndex < CityData.HouseDataList.Count; houseIndex++)
            {
                var houseData = CityData.HouseDataList[houseIndex];
                var house = HouseFactory.Create(houseData);

                var houseSpawnPoint = city.HousesSpawnPoints[houseIndex];
                house.transform.SetPositionAndRotation(houseSpawnPoint);
                Object.Destroy(houseSpawnPoint.gameObject);

                houses.Add(house);
            }

            List<LivingRoom> _livingRooms = houses.SelectMany(x => x.LivingRooms).ToList();
            List<WorkRoom> _workRooms = houses.SelectMany(x => x.WorkRooms).ToList();

            Container.Bind<List<LivingRoom>>().FromInstance(_livingRooms).AsSingle().NonLazy();
            Container.Bind<List<WorkRoom>>().FromInstance(_workRooms).AsSingle().NonLazy();
        }
    }
}