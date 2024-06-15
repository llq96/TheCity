using UnityEngine;

namespace TheCity
{
    [CreateAssetMenu(fileName = "NamesGeneratorSettings", menuName = "TheCity/NamesGeneratorSettings", order = 1)]
    public class NamesGeneratorSettings : ScriptableObject, INamesGeneratorSettings
    {
        [SerializeField] private CitizenPossibleNames _citizenPossibleNames;
        [SerializeField] private StreetPossibleNames _streetPossibleNames;
        [SerializeField] private CompanyPossibleNames _companyPossibleNames;

        public ICitizenPossibleNames CitizenPossibleNames => _citizenPossibleNames;
        public StreetPossibleNames StreetPossibleNames => _streetPossibleNames;
        public CompanyPossibleNames CompanyPossibleNames => _companyPossibleNames;
    }

    public interface INamesGeneratorSettings
    {
        public ICitizenPossibleNames CitizenPossibleNames { get; }
        public StreetPossibleNames StreetPossibleNames { get; }
        public CompanyPossibleNames CompanyPossibleNames { get; }
    }
}