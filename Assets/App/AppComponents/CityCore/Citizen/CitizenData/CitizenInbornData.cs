namespace TheCity.Core
{
    public record CitizenInbornData(
        CitizenName Name,
        LivingAddressData AddressData,
        int HomeRoomStuffIndex, //TODO Change to new class
        JobPost JobPost
    );
}