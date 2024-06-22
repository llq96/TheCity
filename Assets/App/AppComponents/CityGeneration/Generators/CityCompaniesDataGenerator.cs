using System;
using System.Collections.Generic;
using System.Linq;
using TheCity.Core;
using Zenject;

namespace TheCity.CityGeneration
{
    public class CityCompaniesDataGenerator
    {
        [Inject] private ICompanyNamesGenerator CompanyNamesGenerator { get; }
        [Inject] private IPossibleJobTitles PossibleJobTitles { get; }

        public List<CompanyData> GenerateCompanies(int countCompanies, ref List<AddressData> addresses)
        {
            var companiesDataList = new List<CompanyData>();

            for (int i = 0; i < countCompanies; i++)
            {
                var addressData = addresses.First(x => x.AddressType == AddressType.Working);
                addresses.Remove(addressData);

                var newCompanyData = GenerateNewCompanyData(i, addressData.GlobalRoomIndex);
                companiesDataList.Add(newCompanyData);
            }

            return companiesDataList;
        }

        private CompanyData GenerateNewCompanyData(int companyIndex, int addressIndex)
        {
            var randomCompanyName = CompanyNamesGenerator.GetNextCompanyName();
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