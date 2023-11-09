using System.Collections.Generic;
using UnityEngine;

namespace TheCity
{
    [CreateAssetMenu(fileName = "CitizenPossibleNames", menuName = "TheCity/CitizenPossibleNames", order = 1)]
    public class CitizenPossibleNames : ScriptableObject
    {
        [SerializeField] private List<string> _firstNames;
        [SerializeField] private List<string> _secondNames;

        public List<string> FirstNames => _firstNames;
        public List<string> SecondNames => _secondNames;
    }
}