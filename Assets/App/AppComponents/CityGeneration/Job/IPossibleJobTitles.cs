using System.Collections.ObjectModel;

namespace TheCity
{
    public interface IPossibleJobTitles
    {
        ReadOnlyCollection<IJobTitle> JobTitles { get; }
    }
}