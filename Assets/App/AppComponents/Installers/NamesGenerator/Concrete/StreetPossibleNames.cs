using System.Collections.Generic;
using System.Collections.ObjectModel;
using TheCity.CityDataGeneration;
using UnityEngine;

namespace TheCity.Installers
{
    [CreateAssetMenu(fileName = "StreetPossibleNames", menuName = "TheCity/StreetPossibleNames", order = 1)]
    public class StreetPossibleNames : ScriptableObject, IStreetPossibleNames
    {
        [SerializeField] private List<string> _names;

        public ReadOnlyCollection<string> Names => _names.AsReadOnly();
    }
}