using System;
using System.Collections.Generic;
using TheCity.Core;

namespace TheCity.CityDataGeneration
{
    public class CityHousesDataGenerator
    {
        private const int HousesPerStreet = 100;

        private const int LivingAddressesPerHouse = 2;
        private const int WorkAddressesPerHouse = 2;

        public List<HouseData> GenerateHousesByCountAddresses(List<StreetData> streets,
            int countLivingAddresses, int countWorkAddresses)
        {
            int needHousesForLivingAddresses = (int)Math.Ceiling(countLivingAddresses / (float)LivingAddressesPerHouse);
            int needHousesForWorkAddresses = (int)Math.Ceiling(countWorkAddresses / (float)WorkAddressesPerHouse);
            var countHouses = Math.Max(needHousesForLivingAddresses, needHousesForWorkAddresses);

            var houses = new List<HouseData>();

            for (int i = 0; i < countHouses; i++)
            {
                var streetIndex = i / HousesPerStreet;
                var street = streets[streetIndex];
                var houseNumber = i + 1;
                var houseData = new HouseData(street, houseNumber);

                street.HousesData.Add(houseData);
                FillHouseDataAddresses(houseData);

                houses.Add(houseData);
            }

            return houses;
        }

        private void FillHouseDataAddresses(HouseData houseData)
        {
            var roomNumber = 1;
            for (int i = 0; i < LivingAddressesPerHouse; i++)
            {
                var livingAddressData = new LivingAddressData(houseData, roomNumber++);
                houseData.LivingAddressesData.Add(livingAddressData);
            }

            for (int i = 0; i < WorkAddressesPerHouse; i++)
            {
                var workAddressData = new WorkAddressData(houseData, roomNumber++);
                houseData.WorkAddressesData.Add(workAddressData);
            }
        }
    }
}