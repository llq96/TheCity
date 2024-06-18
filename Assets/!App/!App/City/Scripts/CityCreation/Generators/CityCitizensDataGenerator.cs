using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using Zenject;

namespace TheCity.CityGeneration
{
    [UsedImplicitly]
    public class CityCitizensDataGenerator
    {
        private const int CitizenPerAddress = 2;

        [Inject] private NamesGenerator NamesGenerator { get; }

        public List<CitizenData> GenerateCitizens(int countCitizens, ref int addressIndex, List<JobPost> jobPostsList)
        {
            var citizensDataList = new List<CitizenData>();

            var citizensWithCurrentAddress = 0;
            for (int i = 0; i < countCitizens; i++)
            {
                var jobPost = GetRandomJobPostAndRemoveFromList(jobPostsList);
                var companyIndex = jobPost.CompanyData.CompanyIndex;
                var newCitizenData = GenerateNewCitizenData(addressIndex, companyIndex, jobPost.JobPostIndexInCompany);
                citizensDataList.Add(newCitizenData);

                citizensWithCurrentAddress++;
                if (citizensWithCurrentAddress >= CitizenPerAddress)
                {
                    addressIndex++;
                }
            }

            return citizensDataList;
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
    }
}