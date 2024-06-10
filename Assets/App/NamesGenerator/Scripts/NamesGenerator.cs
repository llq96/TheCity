using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;
using Zenject;

namespace TheCity
{
    [UsedImplicitly]
    public class NamesGenerator
    {
        [Inject] private NamesGeneratorSettings Settings { get; }

        private readonly List<CitizenName> _citizenNames = new();
        private readonly List<CompanyName> _companyNames = new();
        private readonly List<StreetName> _streetNames = new();

        public void ClearGeneratedLists()
        {
            _citizenNames.Clear();
            _companyNames.Clear();
            _streetNames.Clear();
        }

        public CitizenName GenerateRandomCitizenName()
        {
            var firstNames = Settings.CitizenPossibleNames.FirstNames;
            var secondNames = Settings.CitizenPossibleNames.SecondNames;
            string firstName;
            string secondName;
            do
            {
                firstName = firstNames[Random.Range(0, firstNames.Count)];
                secondName = secondNames[Random.Range(0, secondNames.Count)];
            } while (_citizenNames.Any(x => x.FirstName == firstName && x.SecondName == secondName));

            var result = new CitizenName(firstName, secondName);
            _citizenNames.Add(result);
            return result;
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


    public struct StreetName
    {
        public string Name { get; }
        public string FullName { get; }

        public StreetName(string name)
        {
            Name = name;
            FullName = $"{name} St.";
        }

        public override string ToString() => FullName;
    }
}