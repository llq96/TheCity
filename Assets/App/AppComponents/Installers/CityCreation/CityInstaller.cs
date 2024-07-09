using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using TheCity.Core;
using TheCity.Unity;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace TheCity.Installers
{
    [UsedImplicitly]
    public class CityInstaller : Installer<CityInstaller>
    {
        [Inject] private CityData CityData { get; }
        [Inject] private CityCreationSettings CityCreationSettings { get; }

        private Transform _addressesParent;

        private readonly List<LivingRoom> _livingRooms = new();
        private readonly List<WorkRoom> _workRooms = new();

        public override void InstallBindings()
        {
            BindComponentsFromHierarchy();

            BindRooms();
        }

        private void BindComponentsFromHierarchy()
        {
            Container.Bind<City>().FromComponentInHierarchy().AsSingle().NonLazy();
        }

        //TODO Вынес это из скрипта Room, но всё ещё без полноценной генерации плохо всё тут
        private void BindRooms()
        {
            var city = Container.Resolve<City>();
            _addressesParent = city.AddressesParent;


            foreach (var addressData in CityData.AddressesDataList)
            {
                var subContainer = Container.CreateSubContainer();
                subContainer.Bind<AddressData>().FromInstance(addressData);
                var room = CreateRoom(addressData);
                subContainer.InjectGameObject(room.gameObject);
            }

            Container.Bind<List<LivingRoom>>().FromInstance(_livingRooms).AsSingle().NonLazy();
            Container.Bind<List<WorkRoom>>().FromInstance(_workRooms).AsSingle().NonLazy();
        }

        private Room CreateRoom(AddressData addressData)
        {
            switch (addressData.AddressType)
            {
                case AddressType.Living:
                    var livingRoom = InstantiateRoom(CityCreationSettings.LivingRoomPrefab);

                    var position = new Vector3(-8, 0, _livingRooms.Count * 12);
                    livingRoom.transform.position = position;
                    livingRoom.transform.rotation = Quaternion.Euler(0, 90, 0);

                    _livingRooms.Add(livingRoom);
                    return livingRoom;
                case AddressType.Working:
                    var workRoom = InstantiateRoom(CityCreationSettings.WorkRoomPrefab);

                    var position2 = new Vector3(8, 0, _workRooms.Count * 12);
                    workRoom.transform.position = position2;
                    workRoom.transform.rotation = Quaternion.Euler(0, -90, 0);

                    _workRooms.Add(workRoom);
                    return workRoom;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private T InstantiateRoom<T>(T prefab) where T : Room
        {
            return Object.Instantiate(prefab, _addressesParent);
        }
    }
}