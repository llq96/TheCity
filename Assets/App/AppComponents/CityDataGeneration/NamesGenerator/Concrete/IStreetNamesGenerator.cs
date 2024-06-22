using TheCity.Core;

namespace TheCity.CityDataGeneration
{
    public interface IStreetNamesGenerator
    {
        StreetName GetNextStreetName();
        void Reset();
    }
}