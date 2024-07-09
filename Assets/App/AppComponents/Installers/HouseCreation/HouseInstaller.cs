using System.Collections.Generic;
using TheCity.Core;
using TheCity.Unity;
using UnityEngine;
using Zenject;

namespace TheCity.Installers
{
    public class HouseInstaller : Installer<HouseInstaller>
    {
        [Inject] private HouseData HouseData { get; }
        [Inject] private CityCreationSettings CityCreationSettings { get; }

        public override void InstallBindings()
        {
            BindComponentsFromHierarchy();

            var house = Container.Resolve<House>();

            List<LivingRoom> _livingRooms = new();
            List<WorkRoom> _workRooms = new();

            for (var i = 0; i < HouseData.LivingAddressesData.Count; i++) //TODO Вынести частично
            {
                var livingAddressData = HouseData.LivingAddressesData[i];
                var subContainer = Container.CreateSubContainer();
                subContainer.Bind<AddressData>().FromInstance(livingAddressData);
                subContainer.Bind<LivingAddressData>().FromInstance(livingAddressData);

                var room = Object.Instantiate(CityCreationSettings.LivingRoomPrefab, house.transform);
                var spawnPoint = house.LivingRoomSpawnPoints[i];
                room.transform.SetPositionAndRotation(spawnPoint);
                subContainer.InjectGameObject(room.gameObject);

                _livingRooms.Add(room);
            }

            for (var i = 0; i < HouseData.WorkAddressesData.Count; i++)
            {
                var workAddressData = HouseData.WorkAddressesData[i];
                var subContainer = Container.CreateSubContainer();
                subContainer.Bind<AddressData>().FromInstance(workAddressData);
                subContainer.Bind<WorkAddressData>().FromInstance(workAddressData);

                var room = Object.Instantiate(CityCreationSettings.WorkRoomPrefab, house.transform);
                var spawnPoint = house.WorkRoomSpawnPoints[i];
                room.transform.SetPositionAndRotation(spawnPoint);
                subContainer.InjectGameObject(room.gameObject);

                _workRooms.Add(room);
            }

            Container.Bind<List<LivingRoom>>().FromInstance(_livingRooms).AsSingle().NonLazy();
            Container.Bind<List<WorkRoom>>().FromInstance(_workRooms).AsSingle().NonLazy();
        }

        private void BindComponentsFromHierarchy()
        {
            Container.Bind<House>().FromComponentInHierarchy().AsSingle().NonLazy();
        }
    }
}