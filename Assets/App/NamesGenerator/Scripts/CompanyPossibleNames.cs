using System.Collections.Generic;
using UnityEngine;

namespace TheCity
{
    [CreateAssetMenu(fileName = "CompanyPossibleNames", menuName = "TheCity/CompanyPossibleNames", order = 1)]
    public class CompanyPossibleNames : ScriptableObject
    {
        [SerializeField] private List<string> _names;
        [SerializeField] private List<string> _types;

        public List<string> Names => _names;
        public List<string> Types => _types;
    }
}