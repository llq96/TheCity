using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Zenject;
using Random = UnityEngine.Random;

namespace TheCity
{
    [UsedImplicitly]
    public class NamesGenerator
    {
        [Inject] private INamesGeneratorSettings Settings { get; }
        [Inject] private CitizensNamesGenerator CitizensNamesGenerator { get; }

        private readonly List<CompanyName> _companyNames = new();
        private readonly List<StreetName> _streetNames = new();

        public void Reset()
        {
            CitizensNamesGenerator.Reset();
            _companyNames.Clear();
            _streetNames.Clear();
        }

        public CitizenName GenerateRandomCitizenName()
        {
            return CitizensNamesGenerator.GetNextCitizenName();
        }

        public CompanyName GenerateRandomCompanyName()
        {
            var names = Settings.CompanyPossibleNames.Names;
            var types = Settings.CompanyPossibleNames.Types;

            string name;
            do
            {
                name = names[Random.Range(0, names.Count)];
            } while (_companyNames.Any(x => x.Name == name));

            var type = types[Random.Range(0, types.Count)];

            var result = new CompanyName(name, type);
            _companyNames.Add(result);
            return result;
        }

        public StreetName GenerateRandomStreetName()
        {
            var names = Settings.StreetPossibleNames.Names;

            string name;
            do
            {
                name = names[Random.Range(0, names.Count)];
            } while (_streetNames.Any(x => x.Name == name));

            var result = new StreetName(name);
            _streetNames.Add(result);
            return result;
        }
    }
}