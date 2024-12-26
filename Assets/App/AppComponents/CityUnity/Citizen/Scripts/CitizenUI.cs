using TMPro;
using UniRx;
using UnityEngine;
using Zenject;

namespace TheCity.Unity.UI
{
    public class CitizenUI : MonoBehaviour
    {
        [Inject] private Citizen Citizen { get; }
        [Inject] private CitizenThinker CitizenThinker { get; }

        [SerializeField] private TextMeshProUGUI _tmp_fullName;
        [SerializeField] private GameObject _thinkObject;
        [SerializeField] private TextMeshProUGUI _tmp_think;

        private void Awake()
        {
            CitizenThinker.LastThink.Subscribe(SetThink);
        }

        public void Start()
        {
            _tmp_fullName.text = Citizen.InbornData.Name.FullName;
        }

        private void SetThink(string think)
        {
            if (string.IsNullOrEmpty(think))
            {
                DisableThink();
                return;
            }

            _thinkObject.SetActive(true);
            _tmp_think.text = think;
        }

        private void DisableThink()
        {
            _thinkObject.SetActive(false);
        }
    }
}