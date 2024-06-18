using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Zenject;
using Random = UnityEngine.Random;

namespace TheCity.CityGeneration
{
    [UsedImplicitly]
    [TestsInfo("CityCompaniesDataGeneratorTests", 100)]
    public class CityCompaniesDataGenerator
    {
        [Inject] private NamesGenerator NamesGenerator { get; }
        [Inject] private IPossibleJobTitles PossibleJobTitles { get; }

        public List<CompanyData> GenerateCompanies(int countCompanies, ref int addressIndex)
        {
            var companiesDataList = new List<CompanyData>();

            for (int i = 0; i < countCompanies; i++)
            {
                var newCompanyData = GenerateNewCompanyData(i, addressIndex);
                addressIndex++;
                companiesDataList.Add(newCompanyData);
            }

            return companiesDataList;
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
    }
}