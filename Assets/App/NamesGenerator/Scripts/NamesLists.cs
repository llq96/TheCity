using System.Collections.Generic;
using UnityEngine;

namespace TheCity
{
    [CreateAssetMenu(fileName = "NamesLists", menuName = "TheCity/NamesLists", order = 1)]
    public class NamesLists : ScriptableObject
    {
        [SerializeField] private List<string> _firstNames;
        [SerializeField] private List<string> _secondNames;

        public List<string> FirstNames => _firstNames;
        public List<string> SecondNames => _secondNames;
    }
}