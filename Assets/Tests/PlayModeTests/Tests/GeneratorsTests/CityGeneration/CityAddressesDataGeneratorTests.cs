using System.Linq;
using NUnit.Framework;
using TheCity.CityGeneration;
using Zenject;

namespace TheCity.Tests
{
    public class CityAddressesDataGeneratorTests : ZenjectEmptyContextsUnitTestFixture
    {
        private static readonly int[] CorrectAddressesCount = { 1, 2, 3, 4, 5, 10, 50 };

        [Inject] private CityAddressesDataGenerator CityAddressesDataGenerator { get; }

        private void CorrectSetUp(int countEachNames)
        {
            PreInstall();

            CorrectThings.BindCorrectNamesGenerator(Container, countEachNames);
            Container.Bind<CityAddressesDataGenerator>().AsSingle().NonLazy();

            PostInstall();
        }

        [Test]
        public void ResolvedCityAddressesDataGenerator_AfterCorrectSetUp_NotNull()
        {
            CorrectSetUp(10);

            Assert.NotNull(CityAddressesDataGenerator);
        }

        [Test, TestCaseSource(nameof(CorrectAddressesCount))]
        public void GenerateAddresses_AfterCorrectSetUp_ReturnsAddressesUniqueByRef(int countAddressesNames)
        {
            CorrectSetUp(countAddressesNames);

            var generateCount = countAddressesNames;
            var addresses = CityAddressesDataGenerator.GenerateAddresses(generateCount);
            var countAfterDistinct = addresses.Distinct().Count();

            Assert.AreEqual(generateCount, countAfterDistinct, $"Addresses:\n{string.Join('\n', addresses)}");
        }

        [Test, TestCaseSource(nameof(CorrectAddressesCount))]
        public void GenerateAddresses_AfterCorrectSetUp_ReturnsAddressesUniqueByGlobalRoomIndex(int countAddressesNames)
        {
            CorrectSetUp(countAddressesNames);

            var generateCount = countAddressesNames;
            var addresses = CityAddressesDataGenerator.GenerateAddresses(generateCount);
            var countDuplicates = addresses.Count(
                address => addresses.Count(x => x.GlobalRoomIndex == address.GlobalRoomIndex) > 1);

            Assert.Zero(countDuplicates, $"Addresses:\n{string.Join('\n', addresses)}");
        }
    }
}