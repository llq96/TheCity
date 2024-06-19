using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;
using UnityEngine.TestTools;

namespace TheCity
{
    public interface ICitizenPossibleNames
    {
        public ReadOnlyCollection<string> FirstNames { get; }
        public ReadOnlyCollection<string> SecondNames { get; }
    }

    [CreateAssetMenu(fileName = "CitizenPossibleNames", menuName = "TheCity/CitizenPossibleNames", order = 1)]
    [ExcludeFromCoverage]
    public class CitizenPossibleNames : ScriptableObject, ICitizenPossibleNames
    {
        [SerializeField] private List<string> _firstNames;
        [SerializeField] private List<string> _secondNames;

        public ReadOnlyCollection<string> FirstNames => _firstNames.AsReadOnly();
        public ReadOnlyCollection<string> SecondNames => _secondNames.AsReadOnly();
    }
}