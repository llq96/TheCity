namespace TheCity
{
    [TestsInfo("CitizenDataTests", 100)]
    public class CitizenData
    {
        public CitizenInbornData CitizenInbornData { get; }

        public CitizenData(CitizenInbornData citizenInbornData)
        {
            CitizenInbornData = citizenInbornData;
        }
    }
}