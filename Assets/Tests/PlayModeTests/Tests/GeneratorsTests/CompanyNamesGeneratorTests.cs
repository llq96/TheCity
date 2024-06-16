using System;
using Zenject;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace TheCity.Tests
{
    public class CompanyNamesGeneratorTests : ZenjectEmptyContextsUnitTestFixture
    {
        [Inject] private CompanyNamesGenerator CompanyNamesGenerator { get; }

        private void CorrectSetUp(int firstNames, int countTypes)
        {
            PreInstall();

            var namesGeneratorSettings =
                CorrectThings.GetINamesGeneratorSettings_WithCompaniesOnly(firstNames, countTypes);
            Container.BindInterfacesAndSelfTo<INamesGeneratorSettings>().FromInstance(namesGeneratorSettings)
                .AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<CompanyNamesGenerator>()
                .AsSingle().NonLazy();

            PostInstall();
        }

        [Test, TestCaseSource(nameof(CountPairs))]
        public void AllNames_ShouldBe_Unique(Tuple<int, int> countsPair)
        {
            CorrectSetUp(countsPair.Item1, countsPair.Item2);

            var count = countsPair.Item1;
            var names = Enumerable.Repeat(0, count)
                .Select(_ => CompanyNamesGenerator.GetNextCompanyName())
                .Select(x => x.Name) //ignore company types
                .ToList();

            var countAfterDistinct = names.Distinct().Count();

            Assert.AreEqual(count, countAfterDistinct);
        }

        [Test, TestCaseSource(nameof(CountPairs))]
        public void ThrowWhen_TryGet_MoreNames_ThanExist(Tuple<int, int> countsPair)
        {
            CorrectSetUp(countsPair.Item1, countsPair.Item2);

            var count = countsPair.Item1;
            var names = Enumerable.Repeat(0, count).Select(_ => CompanyNamesGenerator.GetNextCompanyName()).ToList();

            Assert.Catch(() => CompanyNamesGenerator.GetNextCompanyName());
        }

        private static IEnumerable<Tuple<int, int>> CountPairs()
        {
            for (int i = 1; i <= 5; i++)
            {
                for (int k = 1; k <= 5; k++)
                {
                    yield return new Tuple<int, int>(i, k);
                }
            }
        }
    }
}