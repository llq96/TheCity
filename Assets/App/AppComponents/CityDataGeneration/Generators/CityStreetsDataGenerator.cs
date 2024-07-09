using System.Collections.Generic;
using TheCity.Core;

namespace TheCity.CityDataGeneration
{
    public class CityStreetsDataGenerator
    {
        private readonly IStreetNamesGenerator _streetNamesGenerator;

        public CityStreetsDataGenerator(IStreetNamesGenerator streetNamesGenerator)
        {
            _streetNamesGenerator = streetNamesGenerator;
        }

        public List<StreetData> GenerateStreetsData(int countStreets)
        {
            List<StreetData> streets = new();
            for (int i = 0; i < countStreets; i++)
            {
                var streetName = _streetNamesGenerator.GetNextStreetName();
                var street = new StreetData(streetName);
                streets.Add(street);
            }

            return streets;
        }
    }
}