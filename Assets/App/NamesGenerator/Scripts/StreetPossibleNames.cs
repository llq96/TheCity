using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

namespace TheCity
{
    public interface IStreetPossibleNames
    {
        public ReadOnlyCollection<string> Names { get; }
    }

    [CreateAssetMenu(fileName = "StreetPossibleNames", menuName = "TheCity/StreetPossibleNames", order = 1)]
    public class StreetPossibleNames : ScriptableObject, IStreetPossibleNames
    {
        [SerializeField] private List<string> _names;

        public ReadOnlyCollection<string> Names => _names.AsReadOnly();
    }
}