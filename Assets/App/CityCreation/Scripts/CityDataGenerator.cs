using JetBrains.Annotations;
using Zenject;

namespace TheCity
{
    [UsedImplicitly]
    public class CityDataGenerator
    {
        [Inject] private NamesGenerator NamesGenerator { get; }

        public CityData GenerateCityData(CityGenerationSettings generationSettings = null)
        {
            generationSettings ??= new();

            CityData cityData = new();

            for (int i = 0; i < generationSettings.CountCitizens; i++)
            {
                var newCitizenData = GenerateNewCitizenData();
                cityData.CitizensDataList.Add(newCitizenData);
            }

            return cityData;
        }

        private CitizenData GenerateNewCitizenData()
        {
            NamesGenerator.GenerateRandomName(out var firstName, out var secondName);
            var inbornData = new CitizenInbornData(firstName, secondName);
            var citizenData = new CitizenData(inbornData);
            return citizenData;
        }
    }

    public class CityGenerationSettings
    {
        public int CountCitizens = 3;
    }
}