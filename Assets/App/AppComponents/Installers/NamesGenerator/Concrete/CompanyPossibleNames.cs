using System.Collections.Generic;
using System.Collections.ObjectModel;
using TheCity.CityDataGeneration;
using UnityEngine;

namespace TheCity.Installers
{
    [CreateAssetMenu(fileName = "CompanyPossibleNames", menuName = "TheCity/CompanyPossibleNames", order = 1)]
    public class CompanyPossibleNames : ScriptableObject, ICompanyPossibleNames
    {
        [SerializeField] private List<string> _names;
        [SerializeField] private List<string> _types;

        public ReadOnlyCollection<string> Names => _names.AsReadOnly();
        public ReadOnlyCollection<string> Types => _types.AsReadOnly();
    }
}