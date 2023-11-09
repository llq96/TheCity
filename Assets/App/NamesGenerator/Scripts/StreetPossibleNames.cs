using System.Collections.Generic;
using UnityEngine;

namespace TheCity
{
    [CreateAssetMenu(fileName = "StreetPossibleNames", menuName = "TheCity/StreetPossibleNames", order = 1)]
    public class StreetPossibleNames : ScriptableObject
    {
        [SerializeField] private List<string> _names;

        public List<string> Names => _names;
    }
}