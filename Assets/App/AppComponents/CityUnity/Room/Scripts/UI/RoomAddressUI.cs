using TheCity.Core;
using TMPro;
using UnityEngine;
using Zenject;

namespace TheCity.Unity
{
    public class RoomAddressUI : MonoBehaviour
    {
        [InjectOptional] public AddressData AddressData { get; private set; }

        [SerializeField] private TextMeshProUGUI _tmp_address;

        private void Start()
        {
            UpdateUI();
        }

        private void UpdateUI()
        {
            var text = $"{AddressData.HouseData.StreetData.StreetName} {AddressData.RoomNumber}";
            _tmp_address.text = text;
        }
    }
}