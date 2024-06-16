using System;
using Zenject;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

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