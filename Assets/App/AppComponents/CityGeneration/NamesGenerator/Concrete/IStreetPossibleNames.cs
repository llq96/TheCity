using System.Collections.ObjectModel;

namespace TheCity
{
    public interface IStreetPossibleNames
    {
        public ReadOnlyCollection<string> Names { get; }
    }
}