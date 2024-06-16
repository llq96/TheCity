using System.Collections.Generic;
using System.Linq;
using Moq;
using Zenject;

namespace TheCity.Tests
{
    public static class CorrectThings
    {
        public static CitizenInbornData GetInbornData()
        {
            var citizenName = new CitizenName("John", "Smith");
            var addressIndex = 1;
            var companyIndex = 2;
            var jobPostIndex = 3;

            var citizenInbornData = new CitizenInbornData(citizenName, addressIndex, companyIndex, jobPostIndex);

            return citizenInbornData;
        }

        public static AddressData GetAddressData()
        {
            var street = new StreetName("Wall Street");
            var houseNumber = 1;
            var roomNumber = 2;
            var globalRoomIndex = 3;

            var addressData = new AddressData(street, houseNumber, roomNumber, globalRoomIndex);

            return addressData;
        }

        public static CitizenData GetCitizenData()
        {
            var inbornData = GetInbornData();
            var citizenData = new CitizenData(inbornData);
            return citizenData;
        }

        public static CompanyName GetCompanyName()
        {
            var companyNameStr = "Google";
            var companyType = "Inc";

            var companyName = new CompanyName(companyNameStr, companyType);
            return companyName;
        }

        public static CompanyData GetCompanyData()
        {
            var companyIndex = 1;
            var companyName = GetCompanyName();
            var addressIndex = 2;
            var jobPosts = new List<JobPost>();

            var companyData = new CompanyData(companyIndex, companyName, addressIndex, jobPosts);
            return companyData;
        }

        #region NamesGenerator

        public static void BindNamesGenerator(DiContainer container, int countEachNames)
        {
            var namesGeneratorSettings = GetINamesGeneratorSettings_WithCountEach(countEachNames);
            container.BindInterfacesAndSelfTo<INamesGeneratorSettings>().FromInstance(namesGeneratorSettings)
                .AsSingle().NonLazy();

            container.BindInterfacesAndSelfTo<CitizenNamesGenerator>().AsSingle().NonLazy();
            container.BindInterfacesAndSelfTo<StreetNamesGenerator>().AsSingle().NonLazy();
            container.BindInterfacesAndSelfTo<CompanyNamesGenerator>().AsSingle().NonLazy();

            container.BindInterfacesAndSelfTo<NamesGenerator>().AsSingle().NonLazy();
        }

        #endregion

        #region NamesGeneratorSettings

        public static INamesGeneratorSettings GetINamesGeneratorSettings_WithCountEach(int countEachNames)
        {
            return GetINamesGeneratorSettings(countEachNames, countEachNames, countEachNames,
                countEachNames, countEachNames);
        }

        public static INamesGeneratorSettings GetINamesGeneratorSettings(
            int countFirstNames = 5, int countSecondNames = 5,
            int countStreets = 5,
            int countCompanyNames = 5, int countCompanyTypes = 5)
        {
            var mock = new Mock<INamesGeneratorSettings>();
            var citizenPossibleNamesMock = GetICitizenPossibleNames(countFirstNames, countSecondNames);
            var streetPossibleNamesMock = GetIStreetPossibleNames(countStreets);
            var companyPossibleNamesMock = GetICompanyPossibleNames(countCompanyNames, countCompanyTypes);
            mock.Setup(x => x.CitizenPossibleNames).Returns(citizenPossibleNamesMock);
            mock.Setup(x => x.StreetPossibleNames).Returns(streetPossibleNamesMock);
            mock.Setup(x => x.CompanyPossibleNames).Returns(companyPossibleNamesMock);
            return mock.Object;
        }


        public static INamesGeneratorSettings GetINamesGeneratorSettings_WithCitizensOnly(int countFirstNames,
            int countSecondNames)
        {
            var mock = new Mock<INamesGeneratorSettings>();
            var citizenPossibleNamesMock = GetICitizenPossibleNames(countFirstNames, countSecondNames);
            mock.Setup(x => x.CitizenPossibleNames).Returns(citizenPossibleNamesMock);
            return mock.Object;
        }

        public static INamesGeneratorSettings GetINamesGeneratorSettings_WithStreetNamesOnly(int countStreets)
        {
            var mock = new Mock<INamesGeneratorSettings>();
            var streetPossibleNamesMock = GetIStreetPossibleNames(countStreets);
            mock.Setup(x => x.StreetPossibleNames).Returns(streetPossibleNamesMock);
            return mock.Object;
        }

        public static INamesGeneratorSettings GetINamesGeneratorSettings_WithCompaniesOnly(int countNames,
            int countTypes)
        {
            var mock = new Mock<INamesGeneratorSettings>();
            var companyPossibleNamesMock = GetICompanyPossibleNames(countNames, countTypes);
            mock.Setup(x => x.CompanyPossibleNames).Returns(companyPossibleNamesMock);
            return mock.Object;
        }

        #endregion

        #region PossibleNames

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

        private static ICompanyPossibleNames GetICompanyPossibleNames(int countNames, int countTypes)
        {
            var mock = new Mock<ICompanyPossibleNames>();
            mock.Setup(x => x.Names)
                .Returns(
                    Enumerable.Range(0, countNames)
                        .Select(i => $"Company Name {i}")
                        .ToList()
                        .AsReadOnly());

            mock.Setup(x => x.Types)
                .Returns(Enumerable.Range(0, countTypes)
                    .Select(i => $"Company Type {i}")
                    .ToList()
                    .AsReadOnly());
            return mock.Object;
        }

        #endregion


        public static IPossibleJobTitles GetIPossibleJobTitles(int countTitles)
        {
            var mock = new Mock<IPossibleJobTitles>();
            mock.Setup(x => x.JobTitles)
                .Returns(
                    Enumerable.Range(0, countTitles)
                        .Select(i => GetIJobTitle($"JobTitle{i}"))
                        .ToList()
                        .AsReadOnly());
            return mock.Object;
        }

        public static IJobTitle GetIJobTitle(string name)
        {
            var mock = new Mock<IJobTitle>();
            mock.Setup(x => x.JobName)
                .Returns(name);
            return mock.Object;
        }

        public static TimeOnly GetTimeOnly()
        {
            return new TimeOnly(12, 12);
        }

        public static Activity GetActivity()
        {
            return new Activity();
        }

        public static DayScheduleItem GetDayScheduleItem()
        {
            var timeOnly = GetTimeOnly();
            var activity = GetActivity();

            var dayScheduleItem = new DayScheduleItem(timeOnly, activity);
            return dayScheduleItem;
        }

        public static WeeklySchedule GetWeeklySchedule()
        {
            return new WeeklySchedule();
        }
    }
}