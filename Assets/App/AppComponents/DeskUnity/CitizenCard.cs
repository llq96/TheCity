using TheCity.Core;

namespace DeskCore
{
    public class CitizenCard : DeskCard
    {
        public CitizenData CitizenData { get; }

        public CitizenCard(CitizenData citizenData)
        {
            CitizenData = citizenData;
        }
    }
}