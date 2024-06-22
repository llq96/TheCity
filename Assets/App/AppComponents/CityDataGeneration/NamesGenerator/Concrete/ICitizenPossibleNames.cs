using System.Collections.ObjectModel;

namespace TheCity.CityDataGeneration
{
    public interface ICitizenPossibleNames
    {
        public ReadOnlyCollection<string> FirstNames { get; }
        public ReadOnlyCollection<string> SecondNames { get; }
    }
}