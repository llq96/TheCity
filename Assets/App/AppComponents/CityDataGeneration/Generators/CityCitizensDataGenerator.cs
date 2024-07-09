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

        public List<CitizenData> GenerateCitizens(int countCitizens, List<LivingAddressData> addresses,
            List<JobPost> jobPostsList)
        {
            var citizensDataList = new List<CitizenData>();

            for (int i = 0; i < countCitizens; i++)
            {
                var addressData = addresses.First(x => x.Citizens.Count < CitizenPerAddress);

                var jobPost = GetRandomJobPostAndRemoveFromList(jobPostsList);
                var homeRoomStuffIndex = addressData.Citizens.Count;
                var newCitizenData = GenerateNewCitizenData(
                    addressData,
                    homeRoomStuffIndex,
                    jobPost);
                citizensDataList.Add(newCitizenData);

                addressData.Citizens.Add(newCitizenData);
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

        private CitizenData GenerateNewCitizenData(
            LivingAddressData addressData,
            int homeRoomStuffIndex,
            JobPost jobPost)
        {
            var randomCitizenName = _citizenNamesGenerator.GetNextCitizenName();
            var inbornData = new CitizenInbornData(
                randomCitizenName,
                addressData,
                homeRoomStuffIndex,
                jobPost);
            var citizenData = new CitizenData(inbornData);
            return citizenData;
        }
    }
}