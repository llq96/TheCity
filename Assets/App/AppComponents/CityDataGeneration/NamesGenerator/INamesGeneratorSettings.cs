namespace TheCity.CityDataGeneration
{
    public interface INamesGeneratorSettings
    {
        public ICitizenPossibleNames CitizenPossibleNames { get; }
        public IStreetPossibleNames StreetPossibleNames { get; }
        public ICompanyPossibleNames CompanyPossibleNames { get; }
    }
}