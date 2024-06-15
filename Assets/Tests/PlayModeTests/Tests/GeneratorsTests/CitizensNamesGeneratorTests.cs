using System;
using Zenject;
using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;

namespace TheCity.Tests
{
    public class CitizensNamesGeneratorTests : ZenjectEmptyContextsUnitTestFixture
    {
        [Inject] private CitizensNamesGenerator CitizensNamesGenerator { get; }

        private void CorrectSetUp(int firstNames, int secondNames)
        {
            PreInstall();

            var namesGeneratorSettings = GetINamesGeneratorSettings(firstNames, secondNames);
            Container.BindInterfacesAndSelfTo<INamesGeneratorSettings>().FromInstance(namesGeneratorSettings)
                .AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<CitizensNamesGenerator>()
                .AsSingle().NonLazy();

            PostInstall();
        }

        [Test, TestCaseSource(nameof(CountPairs))]
        public void AllNames_ShouldBe_Unique(Tuple<int, int> countsPair)
        {
            CorrectSetUp(countsPair.Item1, countsPair.Item2);

            var count = countsPair.Item1 * countsPair.Item2;
            var names = Enumerable.Repeat(0, count).Select(_ => CitizensNamesGenerator.GetNextCitizenName()).ToList();
            var countAfterDistinct = names.Distinct().Count();

            Assert.AreEqual(count, countAfterDistinct);
        }

        [Test, TestCaseSource(nameof(CountPairs))]
        public void ThrowWhen_TryGet_MoreNames_ThanExist(Tuple<int, int> countsPair)
        {
            CorrectSetUp(countsPair.Item1, countsPair.Item2);

            var count = countsPair.Item1 * countsPair.Item2;
            var names = Enumerable.Repeat(0, count).Select(_ => CitizensNamesGenerator.GetNextCitizenName()).ToList();

            Assert.Catch(() => CitizensNamesGenerator.GetNextCitizenName());
        }

        private static INamesGeneratorSettings GetINamesGeneratorSettings(int firstNames, int secondNames)
        {
            var mock = new Mock<INamesGeneratorSettings>();
            var citizenPossibleNamesMock = GetICitizenPossibleNames(firstNames, secondNames);
            mock.Setup(x => x.CitizenPossibleNames).Returns(citizenPossibleNamesMock);
            return mock.Object;
        }

        private static ICitizenPossibleNames GetICitizenPossibleNames(int firstNames, int secondNames)
        {
            var mock = new Mock<ICitizenPossibleNames>();
            mock.Setup(x => x.FirstNames)
                .Returns(
                    Enumerable.Range(0, firstNames)
                        .Select(i => $"FN{i}")
                        .ToList()
                        .AsReadOnly());

            mock.Setup(x => x.SecondNames)
                .Returns(Enumerable.Range(0, secondNames)
                    .Select(i => $"SN{i}")
                    .ToList()
                    .AsReadOnly());
            return mock.Object;
        }

        private static IEnumerable<Tuple<int, int>> CountPairs()
        {
            for (int i = 0; i < 5; i++)
            {
                for (int k = 0; k < 5; k++)
                {
                    yield return new Tuple<int, int>(i, k);
                }
            }
        }
    }
}