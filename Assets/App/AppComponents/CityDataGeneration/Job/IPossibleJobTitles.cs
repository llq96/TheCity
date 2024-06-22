using System.Collections.ObjectModel;
using TheCity.Core;

namespace TheCity.CityDataGeneration
{
    public interface IPossibleJobTitles
    {
        ReadOnlyCollection<IJobTitle> JobTitles { get; }
    }
}