using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

namespace TheCity
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