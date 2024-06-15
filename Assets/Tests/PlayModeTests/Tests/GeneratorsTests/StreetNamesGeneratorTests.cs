using Zenject;
using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;

namespace TheCity.Tests
{
    public class StreetNamesGeneratorTests : ZenjectEmptyContextsUnitTestFixture
    {
        [Inject] private StreetNamesGenerator StreetNamesGenerator { get; }

        private void CorrectSetUp(int countStreets)
        {
            PreInstall();

            var namesGeneratorSettings = GetINamesGeneratorSettings(countStreets);
            Container.BindInterfacesAndSelfTo<INamesGeneratorSettings>().FromInstance(namesGeneratorSettings)
                .AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<StreetNamesGenerator>()
                .AsSingle().NonLazy();

            PostInstall();
        }

        [Test, TestCaseSource(nameof(Count_1_To_5))]
        public void AllNames_ShouldBe_Unique(int countStreets)
        {
            CorrectSetUp(countStreets);

            var names = Enumerable.Repeat(0, countStreets)
                .Select(_ => StreetNamesGenerator.GetNextStreetName())
                .ToList();
            var countAfterDistinct = names.Distinct().Count();

            Assert.AreEqual(countStreets, countAfterDistinct, $"Names:\n {string.Join('\n', names)}");
        }

        [Test, TestCaseSource(nameof(Count_1_To_5))]
        public void ThrowWhen_TryGet_MoreNames_ThanExist(int countStreets)
        {
            CorrectSetUp(countStreets);

            var names = Enumerable.Repeat(0, countStreets).Select(_ => StreetNamesGenerator.GetNextStreetName())
                .ToList();

            Assert.Catch(() => StreetNamesGenerator.GetNextStreetName());
        }

        private static INamesGeneratorSettings GetINamesGeneratorSettings(int countStreets)
        {
            var mock = new Mock<INamesGeneratorSettings>();
            var streetPossibleNamesMock = GetIStreetPossibleNames(countStreets);
            mock.Setup(x => x.StreetPossibleNames).Returns(streetPossibleNamesMock);
            return mock.Object;
        }

        private static IStreetPossibleNames GetIStreetPossibleNames(int countStreets)
        {
            var mock = new Mock<IStreetPossibleNames>();
            mock.Setup(x => x.Names)
                .Returns(
                    Enumerable.Range(0, countStreets)
                        .Select(i => $"Street{i}")
                        .ToList()
                        .AsReadOnly());
            return mock.Object;
        }

        private static IEnumerable<int> Count_1_To_5()
        {
            for (int i = 0; i <= 5; i++)
            {
                yield return i;
            }
        }
    }
}