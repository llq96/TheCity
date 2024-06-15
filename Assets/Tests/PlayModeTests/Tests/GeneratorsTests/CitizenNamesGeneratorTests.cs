using System;
using Zenject;
using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;

namespace TheCity.Tests
{
    public class CitizenNamesGeneratorTests : ZenjectEmptyContextsUnitTestFixture
    {
        [Inject] private CitizenNamesGenerator CitizenNamesGenerator { get; }

        private void CorrectSetUp(int countFirstNames, int countSecondNames)
        {
            PreInstall();

            var namesGeneratorSettings = GetINamesGeneratorSettings(countFirstNames, countSecondNames);
            Container.BindInterfacesAndSelfTo<INamesGeneratorSettings>().FromInstance(namesGeneratorSettings)
                .AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<CitizenNamesGenerator>()
                .AsSingle().NonLazy();

            PostInstall();
        }

        [Test, TestCaseSource(nameof(CountPairs))]
        public void AllNames_ShouldBe_Unique(Tuple<int, int> countsPair)
        {
            CorrectSetUp(countsPair.Item1, countsPair.Item2);

            var count = countsPair.Item1 * countsPair.Item2;
            var names = Enumerable.Repeat(0, count).Select(_ => CitizenNamesGenerator.GetNextCitizenName()).ToList();
            var countAfterDistinct = names.Distinct().Count();

            Assert.AreEqual(count, countAfterDistinct, $"Names:\n{string.Join('\n', names)}");
        }

        [Test, TestCaseSource(nameof(CountPairs))]
        public void ThrowWhen_TryGet_MoreNames_ThanExist(Tuple<int, int> countsPair)
        {
            CorrectSetUp(countsPair.Item1, countsPair.Item2);

            var count = countsPair.Item1 * countsPair.Item2;
            var names = Enumerable.Repeat(0, count).Select(_ => CitizenNamesGenerator.GetNextCitizenName()).ToList();

            Assert.Catch(() => CitizenNamesGenerator.GetNextCitizenName());
        }

        private static INamesGeneratorSettings GetINamesGeneratorSettings(int countFirstNames, int countSecondNames)
        {
            var mock = new Mock<INamesGeneratorSettings>();
            var citizenPossibleNamesMock = GetICitizenPossibleNames(countFirstNames, countSecondNames);
            mock.Setup(x => x.CitizenPossibleNames).Returns(citizenPossibleNamesMock);
            return mock.Object;
        }

        private static ICitizenPossibleNames GetICitizenPossibleNames(int countFirstNames, int countSecondNames)
        {
            var mock = new Mock<ICitizenPossibleNames>();
            mock.Setup(x => x.FirstNames)
                .Returns(
                    Enumerable.Range(0, countFirstNames)
                        .Select(i => $"FirstName{i}")
                        .ToList()
                        .AsReadOnly());

            mock.Setup(x => x.SecondNames)
                .Returns(Enumerable.Range(0, countSecondNames)
                    .Select(i => $"SecondName{i}")
                    .ToList()
                    .AsReadOnly());
            return mock.Object;
        }

        private static IEnumerable<Tuple<int, int>> CountPairs()
        {
            for (int i = 1; i <= 10; i++)
            {
                for (int k = 1; k <= 10; k++)
                {
                    yield return new Tuple<int, int>(i, k);
                }
            }
        }
    }
}