using System.Collections.Generic;
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
        [Inject] private CityCreationSettings CityCreationSettings { get; }

        private readonly List<LivingRoom> _livingRooms = new();
        private readonly List<WorkRoom> _workRooms = new();

        public override void InstallBindings()
        {
            BindComponentsFromHierarchy();

            GenerateHouses();
        }

        private void BindComponentsFromHierarchy()
        {
            Container.Bind<City>().FromComponentInHierarchy().AsSingle().NonLazy();
        }

        private void GenerateHouses()
        {
            var city = Container.Resolve<City>();

            for (var houseIndex = 0; houseIndex < CityData.HouseDataList.Count; houseIndex++)
            {
                var houseData = CityData.HouseDataList[houseIndex];
                var houseSpawnPoint = city.HousesSpawnPoints[houseIndex];

                var house = Object.Instantiate(CityCreationSettings.HousePrefab, city.HousesParent);
                house.transform.SetPositionAndRotation(houseSpawnPoint);
                Object.Destroy(houseSpawnPoint.gameObject);

                for (var i = 0; i < houseData.LivingAddressesData.Count; i++) //TODO Вынести частично
                {
                    var livingAddressData = houseData.LivingAddressesData[i];
                    var subContainer = Container.CreateSubContainer();
                    subContainer.Bind<AddressData>().FromInstance(livingAddressData);
                    subContainer.Bind<LivingAddressData>().FromInstance(livingAddressData);

                    var room = Object.Instantiate(CityCreationSettings.LivingRoomPrefab, house.transform);
                    var spawnPoint = house.LivingRoomSpawnPoints[i];
                    room.transform.SetPositionAndRotation(spawnPoint);
                    subContainer.InjectGameObject(room.gameObject);

                    _livingRooms.Add(room);
                }

                for (var i = 0; i < houseData.WorkAddressesData.Count; i++)
                {
                    var workAddressData = houseData.WorkAddressesData[i];
                    var subContainer = Container.CreateSubContainer();
                    subContainer.Bind<AddressData>().FromInstance(workAddressData);
                    subContainer.Bind<WorkAddressData>().FromInstance(workAddressData);

                    var room = Object.Instantiate(CityCreationSettings.WorkRoomPrefab, house.transform);
                    var spawnPoint = house.WorkRoomSpawnPoints[i];
                    room.transform.SetPositionAndRotation(spawnPoint);
                    subContainer.InjectGameObject(room.gameObject);

                    _workRooms.Add(room);
                }
            }

            Container.Bind<List<LivingRoom>>().FromInstance(_livingRooms).AsSingle().NonLazy();
            Container.Bind<List<WorkRoom>>().FromInstance(_workRooms).AsSingle().NonLazy();
        }
    }
}