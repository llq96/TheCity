namespace TheCity.Core
{
    public class CitizenData
    {
        public CitizenInbornData CitizenInbornData { get; }

        public CitizenData(CitizenInbornData citizenInbornData)
        {
            CitizenInbornData = citizenInbornData;
        }
    }
}