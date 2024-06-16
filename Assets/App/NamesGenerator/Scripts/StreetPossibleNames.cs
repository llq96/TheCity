using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;
using UnityEngine.TestTools;

namespace TheCity
{
    public interface IStreetPossibleNames
    {
        public ReadOnlyCollection<string> Names { get; }
    }

    [CreateAssetMenu(fileName = "StreetPossibleNames", menuName = "TheCity/StreetPossibleNames", order = 1)]
    [ExcludeFromCoverage]
    public class StreetPossibleNames : ScriptableObject, IStreetPossibleNames
    {
        [SerializeField] private List<string> _names;

        public ReadOnlyCollection<string> Names => _names.AsReadOnly();
    }
}