using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Zenject;
using Random = UnityEngine.Random;

namespace TheCity
{
    //TODO Разбить на ~4 части
    [UsedImplicitly]
    public class CityDataGenerator
    {
        private const int CitizenPerAddress = 2;
        [Inject] private NamesGenerator NamesGenerator { get; }
        [Inject] private PossibleJobTitles PossibleJobTitles { get; }

        public CityData GenerateCityData(CityGenerationSettings generationSettings = null)
        {
            generationSettings ??= new();

            CityData cityData = new();
            NamesGenerator.ClearGeneratedLists();

            GenerateAddresses(generationSettings, cityData);
            var _currentAddressIndex = 0;
            GenerateCompanies(generationSettings, cityData, ref _currentAddressIndex);
            var jobPostsList = GetJobPostsList(cityData);
            GenerateCitizens(generationSettings, cityData, ref _currentAddressIndex, jobPostsList);

            return cityData;
        }


        #region Addresses

        private void GenerateAddresses(CityGenerationSettings generationSettings, CityData cityData)
        {
            var randomStreetName = NamesGenerator.GenerateRandomStreetName();
            for (int i = 0; i < generationSettings.CountAddresses; i++)
            {
                var newAddressData = new AddressData(randomStreetName, i, Random.Range(10, 50), i);
                cityData.AddressesDataList.Add(newAddressData);
            }
        }

        #endregion

        #region Citizens

        private void GenerateCitizens(CityGenerationSettings generationSettings, CityData cityData,
            ref int addressIndex, List<JobPost> jobPostsList)
        {
            var citizensWithCurrentAddress = 0;
            for (int i = 0; i < generationSettings.CountCitizens; i++)
            {
                var jobPost = GetRandomJobPostAndRemoveFromList(jobPostsList);
                var companyIndex = jobPost.CompanyData.CompanyIndex;
                var newCitizenData = GenerateNewCitizenData(addressIndex, companyIndex, jobPost.JobPostIndexInCompany);
                cityData.CitizensDataList.Add(newCitizenData);

                citizensWithCurrentAddress++;
                if (citizensWithCurrentAddress >= CitizenPerAddress)
                {
                    addressIndex++;
                }
            }
        }

        private JobPost GetRandomJobPostAndRemoveFromList(List<JobPost> jobPostsList)
        {
            var randomIndex = Random.Range(0, jobPostsList.Count);
            var jobPost = jobPostsList[randomIndex];
            jobPostsList.RemoveAt(randomIndex);
            return jobPost;
        }

        private CitizenData GenerateNewCitizenData(int addressIndex, int companyIndex, int jobPostIndex)
        {
            var randomCitizenName = NamesGenerator.GenerateRandomCitizenName();
            var inbornData = new CitizenInbornData(randomCitizenName, addressIndex, companyIndex, jobPostIndex);
            var citizenData = new CitizenData(inbornData);
            return citizenData;
        }

        #endregion

        #region Companies

        private void GenerateCompanies(CityGenerationSettings generationSettings, CityData cityData,
            ref int addressIndex)
        {
            for (int i = 0; i < generationSettings.CountCompanies; i++)
            {
                var newCompanyData = GenerateNewCompanyData(i, addressIndex);
                cityData.CompaniesDataList.Add(newCompanyData);
                addressIndex++;
            }
        }

        private CompanyData GenerateNewCompanyData(int companyIndex, int addressIndex)
        {
            var randomCompanyName = NamesGenerator.GenerateRandomCompanyName();
            var countJobPosts = Random.Range(2, 4); //TODO
            var jobPosts = new List<JobPost>();
            var companyData = new CompanyData(companyIndex, randomCompanyName, addressIndex, jobPosts);

            for (int i = 0; i < countJobPosts; i++)
            {
                var jobTitle = PossibleJobTitles.JobTitles.GetRandomElement();
                var workSchedule = GenerateWorkSchedule();
                var jobPost = new JobPost(i, jobTitle, companyData, workSchedule);
                jobPosts.Add(jobPost);
            }

            return companyData;
        }

        private WeeklySchedule GenerateWorkSchedule()
        {
            //TODO после выноса в отдельный класс сделать менее хардкодно
            var weeklySchedule = new WeeklySchedule();
            for (int i = (int)DayOfWeek.Monday; i <= (int)DayOfWeek.Friday; i++)
            {
                var dayOfWeek = (DayOfWeek)i;
                var daySchedule = weeklySchedule[dayOfWeek];

                var startTimeHour = Random.Range(6, 13);
                var startTimeMinute = Random.Range(0, 4) * 15; //0, 15, 30, 45 
                var startTime = new TimeOnly(startTimeHour, startTimeMinute);
                var startWorkScheduleItem = new DayScheduleItem(startTime, new Activity_StartWork());
                daySchedule.ScheduleItems.Add(startWorkScheduleItem);

                var endWorkTimeHour = startTimeHour + Random.Range(6, 11);
                var endWorkTimeMinute = Random.Range(0, 4) * 15; //0, 15, 30, 45 
                var endWorkTime = new TimeOnly(endWorkTimeHour, endWorkTimeMinute);
                var endWorkScheduleItem = new DayScheduleItem(endWorkTime, new Activity_EndWork());
                daySchedule.ScheduleItems.Add(endWorkScheduleItem);
            }

            return weeklySchedule;
        }

        private List<JobPost> GetJobPostsList(CityData cityData)
        {
            var _jobPosts = new List<JobPost>();
            foreach (var companyData in cityData.CompaniesDataList)
            {
                foreach (var jobPost in companyData.JobPosts)
                {
                    _jobPosts.Add(jobPost);
                }
            }

            return _jobPosts;
        }

        #endregion
    }

    public class CityGenerationSettings
    {
        public int CountCitizens = 6;
        public int CountCompanies = 3;
        public int CountAddresses = 9;
    }
}