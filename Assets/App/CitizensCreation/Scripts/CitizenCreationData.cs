namespace TheCity
{
    public class CitizenCreationData
    {
        public CitizenInbornData CitizenInbornData { get; }

        public CitizenCreationData(CitizenInbornData citizenInbornData)
        {
            CitizenInbornData = citizenInbornData;
        }
    }
}