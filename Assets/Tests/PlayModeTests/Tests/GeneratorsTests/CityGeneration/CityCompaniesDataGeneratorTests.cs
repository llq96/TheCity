using System.Linq;
using NUnit.Framework;
using TheCity.CityGeneration;
using Zenject;

namespace TheCity.Tests
{
    public class CityCompaniesDataGeneratorTests : ZenjectEmptyContextsUnitTestFixture
    {
        private static readonly int[] CorrectCompaniesCount = { 1, 2, 3, 4, 5, 10, 50 };

        [Inject] private CityCompaniesDataGenerator CityCompaniesDataGenerator { get; }

        private void CorrectSetUp(int countEachNames)
        {
            PreInstall();

            CorrectThings.BindNamesGenerator(Container, countEachNames);

            var possibleJobTitles = CorrectThings.GetIPossibleJobTitles(countEachNames);
            Container.Bind<IPossibleJobTitles>().FromInstance(possibleJobTitles).AsSingle().NonLazy();
            Container.Bind<CityCompaniesDataGenerator>().AsSingle().NonLazy();

            PostInstall();
        }

        [Test]
        public void ResolvedCityCompaniesDataGenerator_AfterCorrectSetUp_NotNull()
        {
            CorrectSetUp(10);

            Assert.NotNull(CityCompaniesDataGenerator);
        }

        [Test, TestCaseSource(nameof(CorrectCompaniesCount))]
        public void GenerateCompanies_AfterCorrectSetUp_ReturnsCompaniesUniqueByRef(int countCompaniesNames)
        {
            CorrectSetUp(countCompaniesNames);

            var generateCount = countCompaniesNames;
            int addressIndex = 0;
            var companies = CityCompaniesDataGenerator.GenerateCompanies(generateCount, ref addressIndex);
            var countAfterDistinct = companies.Distinct().Count();

            Assert.AreEqual(generateCount, countAfterDistinct, $"Companies:\n{string.Join('\n', companies)}");
        }

        [Test, TestCaseSource(nameof(CorrectCompaniesCount))]
        public void GenerateCompanies_AfterCorrectSetUp_ReturnsCompaniesUniqueByName(int countCompaniesNames)
        {
            CorrectSetUp(countCompaniesNames);

            var generateCount = countCompaniesNames;
            int addressIndex = 0;
            var companies = CityCompaniesDataGenerator.GenerateCompanies(generateCount, ref addressIndex);
            var countDuplicates = companies.Count(company =>
                companies.Count(x => x.CompanyName.Name == company.CompanyName.Name) > 1);

            Assert.Zero(countDuplicates, $"Companies:\n{string.Join('\n', companies)}");
        }
    }
}