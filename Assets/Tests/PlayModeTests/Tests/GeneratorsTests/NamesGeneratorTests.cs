using System.Linq;
using Zenject;
using NUnit.Framework;

namespace TheCity.Tests
{
    public class NamesGeneratorTests : ZenjectEmptyContextsUnitTestFixture
    {
        [Inject] private NamesGenerator NamesGenerator { get; }

        private void CorrectSetUp(int countEachNames)
        {
            PreInstall();

            CorrectThings.BindNamesGenerator(Container, countEachNames);

            PostInstall();
        }

        [Test]
        public void ResolvedNamesGenerator_AfterCorrectSetUp_NotNull()
        {
            CorrectSetUp(1);

            Assert.NotNull(NamesGenerator);
        }

        [Test]
        public void GenerateRandomNames_AfterGetAllNames_Throw()
        {
            CorrectSetUp(10);

            Enumerable.Repeat(0, 10 * 10).ToList().ForEach(_ => NamesGenerator.GenerateRandomCitizenName());
            Enumerable.Repeat(0, 10).ToList().ForEach(_ => NamesGenerator.GenerateRandomStreetName());
            Enumerable.Repeat(0, 10).ToList().ForEach(_ => NamesGenerator.GenerateRandomCompanyName());

            Assert.Catch(() => NamesGenerator.GenerateRandomCitizenName());
            Assert.Catch(() => NamesGenerator.GenerateRandomStreetName());
            Assert.Catch(() => NamesGenerator.GenerateRandomCompanyName());
        }
    }
}