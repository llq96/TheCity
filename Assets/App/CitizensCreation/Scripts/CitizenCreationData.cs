namespace TheCity
{
    public class CitizenCreationData
    {
        public CitizenData CitizenData { get; }

        public CitizenCreationData(CitizenData citizenData)
        {
            CitizenData = citizenData;
        }
    }
}