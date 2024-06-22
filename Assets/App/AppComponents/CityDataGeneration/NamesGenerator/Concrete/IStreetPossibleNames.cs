using System.Collections.ObjectModel;

namespace TheCity.CityDataGeneration
{
    public interface IStreetPossibleNames
    {
        public ReadOnlyCollection<string> Names { get; }
    }
}