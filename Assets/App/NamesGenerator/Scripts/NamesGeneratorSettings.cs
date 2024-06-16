using UnityEngine;
using UnityEngine.TestTools;

namespace TheCity
{
    public interface INamesGeneratorSettings
    {
        public ICitizenPossibleNames CitizenPossibleNames { get; }
        public IStreetPossibleNames StreetPossibleNames { get; }
        public ICompanyPossibleNames CompanyPossibleNames { get; }
    }

    [CreateAssetMenu(fileName = "NamesGeneratorSettings", menuName = "TheCity/NamesGeneratorSettings", order = 1)]
    [ExcludeFromCoverage]
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