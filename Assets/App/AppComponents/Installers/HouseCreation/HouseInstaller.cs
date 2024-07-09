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

            CreateRooms();
        }

        private void BindComponentsFromHierarchy()
        {
            Container.Bind<House>().FromComponentInHierarchy().AsSingle().NonLazy();
        }

        private void CreateRooms()
        {
            var house = Container.Resolve<House>();

            List<LivingRoom> _livingRooms = CreateRooms(
                HouseData.LivingAddressesData,
                CityCreationSettings.LivingRoomPrefab,
                house.LivingRoomSpawnPoints,
                house.transform);
            List<WorkRoom> _workRooms = CreateRooms(
                HouseData.WorkAddressesData,
                CityCreationSettings.WorkRoomPrefab,
                house.WorkRoomSpawnPoints,
                house.transform);

            Container.Bind<List<LivingRoom>>().FromInstance(_livingRooms).AsSingle().NonLazy();
            Container.Bind<List<WorkRoom>>().FromInstance(_workRooms).AsSingle().NonLazy();
        }

        private List<TRoom> CreateRooms<TAddressData, TRoom>(
            List<TAddressData> addressesData,
            TRoom prefab,
            List<Transform> spawnPoints,
            Transform parent)
            where TAddressData : AddressData
            where TRoom : Room
        {
            List<TRoom> rooms = new();

            for (var i = 0; i < addressesData.Count; i++)
            {
                var addressData = addressesData[i];
                var spawnPoint = spawnPoints[i];

                var subContainer = Container.CreateSubContainer();
                subContainer.Bind<AddressData>().FromInstance(addressData);
                subContainer.Bind<TAddressData>().FromInstance(addressData);

                var room = Object.Instantiate(prefab, parent);

                room.transform.SetPositionAndRotation(spawnPoint);
                subContainer.InjectGameObject(room.gameObject);
                
                rooms.Add(room);
            }

            return rooms;
        }
    }
}