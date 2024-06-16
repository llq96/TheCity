using Zenject;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace TheCity.Tests
{
    public class StreetNamesGeneratorTests : ZenjectEmptyContextsUnitTestFixture
    {
        [Inject] private StreetNamesGenerator StreetNamesGenerator { get; }

        private void CorrectSetUp(int countStreets)
        {
            PreInstall();

            var namesGeneratorSettings = CorrectThings.GetINamesGeneratorSettings_WithStreetNamesOnly(countStreets);
            Container.BindInterfacesAndSelfTo<INamesGeneratorSettings>().FromInstance(namesGeneratorSettings)
                .AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<StreetNamesGenerator>()
                .AsSingle().NonLazy();

            PostInstall();
        }

        [Test, TestCaseSource(nameof(Count_1_To_5))]
        public void GetNextStreetName_AfterCorrectSetUp_ReturnsUniqueNames(int countStreets)
        {
            CorrectSetUp(countStreets);

            var names = Enumerable.Repeat(0, countStreets)
                .Select(_ => StreetNamesGenerator.GetNextStreetName())
                .ToList();
            var countAfterDistinct = names.Distinct().Count();

            Assert.AreEqual(countStreets, countAfterDistinct, $"Names:\n {string.Join('\n', names)}");
        }

        [Test, TestCaseSource(nameof(Count_1_To_5))]
        public void GetNextStreetName_AfterGetAllNames_Throw(int countStreets)
        {
            CorrectSetUp(countStreets);

            var names = Enumerable.Repeat(0, countStreets).Select(_ => StreetNamesGenerator.GetNextStreetName())
                .ToList();

            Assert.Catch(() => StreetNamesGenerator.GetNextStreetName());
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