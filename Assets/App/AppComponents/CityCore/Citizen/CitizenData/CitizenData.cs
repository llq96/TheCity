namespace TheCity
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