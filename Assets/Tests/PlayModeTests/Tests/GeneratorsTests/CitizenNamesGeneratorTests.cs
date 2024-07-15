using System;
using TheCity.Installers;
using TheCity.CityDataGeneration;
using Zenject;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UnityEngine;

namespace TheCity.Tests
{
    public class CitizenNamesGeneratorTests : ZenjectEmptyContextsUnitTestFixture
    {
        [Inject] private CitizenNamesGenerator CitizenNamesGenerator { get; }

        private void CorrectSetUp(int countFirstNames, int countSecondNames)
        {
            PreInstall();

            var namesGeneratorSettings =
                CorrectThings.GetINamesGeneratorSettings_WithCitizensOnly(countFirstNames, countSecondNames);
            Container.BindInterfacesAndSelfTo<INamesGeneratorSettings>().FromInstance(namesGeneratorSettings)
                .AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<CitizenNamesGenerator>()
                .AsSingle().NonLazy();

            PostInstall();
        }

        [Test, TestCaseSource(nameof(CountPairs))]
        public void GetNextCitizenName_AfterCorrectSetUp_ReturnsUniqueNames(Tuple<int, int> countsPair)
        {
            CorrectSetUp(countsPair.Item1, countsPair.Item2);

            var count = countsPair.Item1 * countsPair.Item2;
            var names = Enumerable.Repeat(0, count).Select(_ => CitizenNamesGenerator.GetNextCitizenName()).ToList();
            var countAfterDistinct = names.Distinct().Count();

            Assert.AreEqual(count, countAfterDistinct, $"Names:\n{string.Join('\n', names)}");
        }

        [Test, TestCaseSource(nameof(CountPairs))]
        public void GetNextCitizenName_AfterGetAllNames_Throw(Tuple<int, int> countsPair)
        {
            CorrectSetUp(countsPair.Item1, countsPair.Item2);

            var count = countsPair.Item1 * countsPair.Item2;
            var names = Enumerable.Repeat(0, count).Select(_ => CitizenNamesGenerator.GetNextCitizenName()).ToList();

            Assert.Catch(() => CitizenNamesGenerator.GetNextCitizenName());
        }


        [Test]
        [TestCaseSource(nameof(CountPairs_Horizontal))]
        [TestCaseSource(nameof(CountPairs_Square))]
        public void GetNextCitizenName_WhenFirstCircleOfGeneration_ReturnUniqueFirstNames(Tuple<int, int> countsPair)
        {
            CorrectSetUp(countsPair.Item1, countsPair.Item2);

            var count = countsPair.Item1;
            var names = Enumerable.Repeat(0, count).Select(_ => CitizenNamesGenerator.GetNextCitizenName()).ToList();
            var repeatFirstNames = names.Select(x => x.FirstName).GroupBy(x => x).Count(g => g.Count() > 1);

            Assert.AreEqual(0, repeatFirstNames);
        }

        [Test]
        [TestCaseSource(nameof(CountPairs_Vertical))]
        [TestCaseSource(nameof(CountPairs_Square))]
        public void GetNextCitizenName_WhenFirstCircleOfGeneration_ReturnUniqueSecondsNames(Tuple<int, int> countsPair)
        {
            CorrectSetUp(countsPair.Item1, countsPair.Item2);

            var count = countsPair.Item2;
            var names = Enumerable.Repeat(0, count).Select(_ => CitizenNamesGenerator.GetNextCitizenName()).ToList();
            var repeatFirstNames = names.Select(x => x.SecondName).GroupBy(x => x).Count(g => g.Count() > 1);

            Assert.AreEqual(0, repeatFirstNames);
        }

        private static IEnumerable<Tuple<int, int>> CountPairs()
        {
            for (int i = 1; i <= 20; i++)
            {
                for (int k = 1; k <= 20; k++)
                {
                    yield return new Tuple<int, int>(i, k);
                }
            }
        }

        private static IEnumerable<Tuple<int, int>> CountPairs_Horizontal() =>
            CountPairs().Where(pair => pair.Item1 > pair.Item2);

        private static IEnumerable<Tuple<int, int>> CountPairs_Vertical() =>
            CountPairs().Where(pair => pair.Item1 > pair.Item2);

        private static IEnumerable<Tuple<int, int>> CountPairs_Square() =>
            CountPairs().Where(pair => pair.Item1 == pair.Item2);
    }
}