using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;
using UnityEngine.TestTools;

namespace TheCity
{
    public interface ICompanyPossibleNames
    {
        ReadOnlyCollection<string> Names { get; }
        ReadOnlyCollection<string> Types { get; }
    }

    [CreateAssetMenu(fileName = "CompanyPossibleNames", menuName = "TheCity/CompanyPossibleNames", order = 1)]
    [ExcludeFromCoverage]
    public class CompanyPossibleNames : ScriptableObject, ICompanyPossibleNames
    {
        [SerializeField] private List<string> _names;
        [SerializeField] private List<string> _types;

        public ReadOnlyCollection<string> Names => _names.AsReadOnly();
        public ReadOnlyCollection<string> Types => _types.AsReadOnly();
    }
}