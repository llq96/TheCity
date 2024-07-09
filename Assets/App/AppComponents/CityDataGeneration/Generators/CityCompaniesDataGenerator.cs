using System;
using System.Collections.Generic;
using System.Linq;
using TheCity.Core;

namespace TheCity.CityDataGeneration
{
    public class CityCompaniesDataGenerator
    {
        private readonly ICompanyNamesGenerator _companyNamesGenerator;
        private readonly IPossibleJobTitles _possibleJobTitles;

        public CityCompaniesDataGenerator(
            ICompanyNamesGenerator companyNamesGenerator,
            IPossibleJobTitles possibleJobTitles)
        {
            _companyNamesGenerator = companyNamesGenerator;
            _possibleJobTitles = possibleJobTitles;
        }

        public List<CompanyData> GenerateCompanies(int countCompanies, List<WorkAddressData> addresses)
        {
            var companiesDataList = new List<CompanyData>();

            for (int i = 0; i < countCompanies; i++)
            {
                var addressData = addresses.First(x => x.Companies.Count < 1);

                var newCompanyData = GenerateNewCompanyData(addressData);
                addressData.Companies.Add(newCompanyData);

                companiesDataList.Add(newCompanyData);
            }

            return companiesDataList;
        }

        private CompanyData GenerateNewCompanyData(WorkAddressData addressData)
        {
            var randomCompanyName = _companyNamesGenerator.GetNextCompanyName();
            var countJobPosts = Random.Range(2, 4); //TODO
            var jobPosts = new List<JobPost>();
            var companyData = new CompanyData(randomCompanyName, addressData, jobPosts);

            for (int i = 0; i < countJobPosts; i++)
            {
                var jobTitle = _possibleJobTitles.JobTitles.GetRandomElement();
                var workSchedule = GenerateWorkSchedule();
                var jobPost = new JobPost(jobTitle, companyData, workSchedule);
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