using System.Collections.ObjectModel;

namespace TheCity
{
    public interface ICompanyPossibleNames
    {
        ReadOnlyCollection<string> Names { get; }
        ReadOnlyCollection<string> Types { get; }
    }
}