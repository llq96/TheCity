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


        [Test, TestCaseSource(nameof(CountPairs))]
        public void GetNextCitizenName_GoodUnique(Tuple<int, int> countsPair) //TODO Хорошая уникальность, придумать имя
        {
            CorrectSetUp(countsPair.Item1, countsPair.Item2);
            var maxSize = Math.Max(countsPair.Item1, countsPair.Item2);

            // var count = countsPair.Item1 * countsPair.Item2;
            var names = Enumerable.Repeat(0, maxSize).Select(_ => CitizenNamesGenerator.GetNextCitizenName()).ToList();
            var countAfterDistinct = names.Distinct().Count();
            var repeatFirstNames = names.Select(x => x.FirstName).GroupBy(x => x).Count(g => g.Count() > 1);
            var repeatSecondNames = names.Select(x => x.SecondName).GroupBy(x => x).Count(g => g.Count() > 1);
            var repeats = repeatFirstNames + repeatSecondNames;

            Debug.Log($"Size ({countsPair.Item1}x{countsPair.Item2}), " +
                      $"Repeats {repeatFirstNames}+{repeatSecondNames} = {repeats} \n" +
                      $"{maxSize} {countAfterDistinct} {names.Count} \n");


            var isCorrect = repeatFirstNames == 0 || repeatSecondNames == 0;
            Assert.True(isCorrect);
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