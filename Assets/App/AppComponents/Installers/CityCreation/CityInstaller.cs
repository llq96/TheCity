using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using TheCity.Core;
using TheCity.Unity;
using Zenject;

namespace TheCity.Installers
{
    [UsedImplicitly]
    public class CityInstaller : Installer<CityInstaller>
    {
        [Inject] private CityData CityData { get; }

        public override void InstallBindings()
        {
            ReBindFactoryParameters();
            BindComponentsFromHierarchy();

            BindRooms();
        }

        private void ReBindFactoryParameters()
        {
            Container.Bind<CityData>().FromInstance(CityData).AsSingle().NonLazy();
        }

        private void BindComponentsFromHierarchy()
        {
            Container.Bind<City>().FromComponentInHierarchy().AsSingle().NonLazy();
        }

        //TODO Вынес это из скрипта Room, но всё ещё без полноценной генерации плохо всё тут
        private void BindRooms()
        {
            var city = Container.Resolve<City>();

            var livingRooms = new Queue<LivingRoom>(city.LivingRooms);
            var workRooms = new Queue<WorkRoom>(city.WorkRooms);

            foreach (var addressData in CityData.AddressesDataList)
            {
                var subContainer = Container.CreateSubContainer();
                subContainer.Bind<AddressData>().FromInstance(addressData);
                var room = GetRoom(addressData);
                subContainer.Inject(room);
            }

            return;

            //Держится на том, что в префабе города изначально как минимум нужное количество комнат всех типов.
            Room GetRoom(AddressData addressData) =>
                addressData.AddressType switch
                {
                    AddressType.Living => livingRooms.Dequeue(),
                    AddressType.Working => workRooms.Dequeue(),
                    _ => throw new ArgumentOutOfRangeException()
                };
        }
    }
}