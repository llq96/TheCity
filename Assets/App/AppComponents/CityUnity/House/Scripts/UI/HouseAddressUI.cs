using TheCity.Core;
using TMPro;
using UnityEngine;
using Zenject;

namespace TheCity.Unity
{
    public class HouseAddressUI : MonoBehaviour
    {
        [Inject] public HouseData HouseData { get; private set; }

        [SerializeField] private TextMeshProUGUI _tmp_address;

        private void Start()
        {
            UpdateUI();
        }

        private void UpdateUI()
        {
            var text = $"{HouseData.StreetData.StreetName} {HouseData.HouseNumber}";
            _tmp_address.text = text;
        }
    }
}