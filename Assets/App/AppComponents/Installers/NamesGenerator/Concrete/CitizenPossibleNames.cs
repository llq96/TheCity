using System.Collections.Generic;
using System.Collections.ObjectModel;
using TheCity.CityDataGeneration;
using UnityEngine;

namespace TheCity.Installers
{
    [CreateAssetMenu(fileName = "CitizenPossibleNames", menuName = "TheCity/CitizenPossibleNames", order = 1)]
    public class CitizenPossibleNames : ScriptableObject, ICitizenPossibleNames
    {
        [SerializeField] private List<string> _firstNames;
        [SerializeField] private List<string> _secondNames;

        public ReadOnlyCollection<string> FirstNames => _firstNames.AsReadOnly();
        public ReadOnlyCollection<string> SecondNames => _secondNames.AsReadOnly();
    }
}