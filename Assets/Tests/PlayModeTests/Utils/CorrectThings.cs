using System.Collections.Generic;

namespace TheCity.Tests
{
    public static class CorrectThings
    {
        public static CitizenInbornData GetCorrectInbornData()
        {
            var citizenName = new CitizenName("John", "Smith");
            var addressIndex = 1;
            var companyIndex = 2;
            var jobPostIndex = 3;

            var citizenInbornData = new CitizenInbornData(citizenName, addressIndex, companyIndex, jobPostIndex);

            return citizenInbornData;
        }

        public static AddressData GetCorrectAddressData()
        {
            var street = new StreetName("Wall Street");
            var houseNumber = 1;
            var roomNumber = 2;
            var globalRoomIndex = 3;

            var addressData = new AddressData(street, houseNumber, roomNumber, globalRoomIndex);

            return addressData;
        }

        public static CitizenData GetCorrectCitizenData()
        {
            var inbornData = GetCorrectInbornData();
            var citizenData = new CitizenData(inbornData);
            return citizenData;
        }

        public static CompanyName GetCorrectCompanyName()
        {
            var companyNameStr = "Google";
            var companyType = "Inc";

            var companyName = new CompanyName(companyNameStr, companyType);
            return companyName;
        }

        public static CompanyData GetCorrectCompanyData()
        {
            var companyIndex = 1;
            var companyName = GetCorrectCompanyName();
            var addressIndex = 2;
            var jobPosts = new List<JobPost>();

            var companyData = new CompanyData(companyIndex, companyName, addressIndex, jobPosts);
            return companyData;
        }
    }
}