using TMPro;
using UnityEngine;
using Zenject;

namespace TheCity.Unity.UI
{
    public class GameTimeUI : MonoBehaviour
    {
        [Inject] private GameTime GameTime { get; }

        [SerializeField] private TextMeshProUGUI _tmp_date;
        [SerializeField] private TextMeshProUGUI _tmp_time;
        [SerializeField] private TextMeshProUGUI _tmp_timeSpeedMultiplier;

        private void Update()
        {
            // UpdateTexts_AsLongDateAndTime();
            UpdateTexts_Custom();
        }

        private void UpdateTexts_Custom()
        {
            _tmp_date.text = GameTime.GameDateTime.ToString("dd.MM.yyyy ddd");
            _tmp_time.text = GameTime.GameDateTime.ToString("HH:mm");

            var multiplier = GameTime.GetTimeSpeedMultiplier();
            _tmp_timeSpeedMultiplier.text = $"x{multiplier}";
        }

        private void UpdateTexts_AsLongDateAndTime()
        {
            _tmp_date.text = GameTime.GameDateTime.ToLongDateString();
            _tmp_time.text = GameTime.GameDateTime.ToLongTimeString();
        }
    }
}