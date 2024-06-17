using System;
using NUnit.Framework;

namespace TheCity.Tests.GameTimeTests
{
    [TestFixture]
    public class GameTimeWrongInputTests : BaseGameTimeTests
    {
        private static readonly int[] WrongYears = { -1, 0, 10000 };
        private static readonly int[] WrongMonths = { -1, 0, 13 };

        [Test, TestCaseSource(nameof(WrongYears))]
        public void BindGameTime_WhenWrongYear_Throw(int wrongYear)
        {
            var initialSettingsMock = CorrectThings.GetIGameTimeInitialSettingsMock();
            initialSettingsMock
                .Setup(x => x.StartDateTime)
                .Returns(() => new DateTime(wrongYear, 1, 1));

            Assert.Catch(() => SetUp(initialSettingsMock.Object));
        }

        [Test, TestCaseSource(nameof(WrongMonths))]
        public void BindGameTime_WhenWrongMonth_Throw(int wrongMonth)
        {
            var initialSettingsMock = CorrectThings.GetIGameTimeInitialSettingsMock();
            initialSettingsMock
                .Setup(x => x.StartDateTime)
                .Returns(() => new DateTime(2000, wrongMonth, 1));

            Assert.Catch(() => SetUp(initialSettingsMock.Object));
        }
    }
}