using TheCity.Core;
using TMPro;
using UnityEngine;

namespace DeskUnity
{
    public class CitizenDeskCardUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _tmp_citizenName;

        public CitizenData CitizenData { get; private set; }

        public void SetCitizenData(CitizenData citizenData)
        {
            CitizenData = citizenData;
            if (CitizenData != null)
            {
                var fullName = CitizenData.CitizenInbornData.Name.FullName;
                gameObject.name = $"Citizen Card ({fullName})";
                _tmp_citizenName.text = fullName;
            }
        }
    }
}