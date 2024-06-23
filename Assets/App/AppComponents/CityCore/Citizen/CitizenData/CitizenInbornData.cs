namespace TheCity.Core
{
    public record CitizenInbornData(
        CitizenName Name,
        int AddressIndex,
        int HomeRoomStuffIndex,
        int CompanyIndex,
        int JobPostIndex
    );
}