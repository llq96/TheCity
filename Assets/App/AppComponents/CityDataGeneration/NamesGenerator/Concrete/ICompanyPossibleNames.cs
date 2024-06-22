using System.Collections.ObjectModel;

namespace TheCity.CityDataGeneration
{
    public interface ICompanyPossibleNames
    {
        ReadOnlyCollection<string> Names { get; }
        ReadOnlyCollection<string> Types { get; }
    }
}