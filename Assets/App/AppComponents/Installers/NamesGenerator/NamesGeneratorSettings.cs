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
        public IStreetPossibleNames StreetPossibleNames => _streetPossibleNames;
        public ICompanyPossibleNames CompanyPossibleNames => _companyPossibleNames;
    }
}