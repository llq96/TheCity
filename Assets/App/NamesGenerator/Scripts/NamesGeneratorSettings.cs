using UnityEngine;

namespace TheCity
{
    [CreateAssetMenu(fileName = "NamesGeneratorSettings", menuName = "TheCity/NamesGeneratorSettings", order = 1)]
    public class NamesGeneratorSettings : ScriptableObject
    {
        [SerializeField] private NamesLists _namesLists;

        public NamesLists NamesLists => _namesLists;
    }
}