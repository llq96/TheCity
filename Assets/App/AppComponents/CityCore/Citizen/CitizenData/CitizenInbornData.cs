namespace TheCity.Core
{
    public record CitizenInbornData(
        CitizenName Name,
        LivingAddressData AddressData,
        int HomeRoomStuffIndex,
        JobPost JobPost
    );
}