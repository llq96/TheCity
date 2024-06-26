using System.Collections.Generic;
using System.Linq;
using TheCity.Core;

namespace TheCity.CityDataGeneration
{
    public class CityCitizensDataGenerator
    {
        private readonly ICitizenNamesGenerator _citizenNamesGenerator;

        private const int CitizenPerAddress = 2;

        public CityCitizensDataGenerator(ICitizenNamesGenerator citizenNamesGenerator)
        {
            _citizenNamesGenerator = citizenNamesGenerator;
        }

        public List<CitizenData> GenerateCitizens(int countCitizens, ref List<AddressData> addresses,
            List<JobPost> jobPostsList)
        {
            var citizensDataList = new List<CitizenData>();

            var citizensWithCurrentAddress = 0;
            AddressData currentAddress = null;
            for (int i = 0; i < countCitizens; i++)
            {
                if (citizensWithCurrentAddress == 0 || citizensWithCurrentAddress >= CitizenPerAddress)
                {
                    citizensWithCurrentAddress = 0;
                    currentAddress = addresses.First(x => x.AddressType == AddressType.Living);
                    addresses.Remove(currentAddress);
                }

                var jobPost = GetRandomJobPostAndRemoveFromList(jobPostsList);
                var companyIndex = jobPost.CompanyData.CompanyIndex;
                var newCitizenData = GenerateNewCitizenData(
                    currentAddress.GlobalRoomIndex,
                    citizensWithCurrentAddress,
                    companyIndex,
                    jobPost.JobPostIndexInCompany);
                citizensDataList.Add(newCitizenData);

                citizensWithCurrentAddress++;
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

        private CitizenData GenerateNewCitizenData(int addressIndex, int homeRoomStuffIndex, int companyIndex,
            int jobPostIndex)
        {
            var randomCitizenName = _citizenNamesGenerator.GetNextCitizenName();
            var inbornData = new CitizenInbornData(
                randomCitizenName,
                addressIndex,
                homeRoomStuffIndex,
                companyIndex,
                jobPostIndex);
            var citizenData = new CitizenData(inbornData);
            return citizenData;
        }
    }
}