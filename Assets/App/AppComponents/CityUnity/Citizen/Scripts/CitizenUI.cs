using TMPro;
using UnityEngine;
using Zenject;

namespace TheCity.Unity.UI
{
    public class CitizenUI : MonoBehaviour
    {
        [Inject] private Citizen Citizen { get; }

        [SerializeField] private TextMeshProUGUI _tmp_fullName;

        public void Start()
        {
            _tmp_fullName.text = Citizen.InbornData.Name.FullName;
        }
    }
}