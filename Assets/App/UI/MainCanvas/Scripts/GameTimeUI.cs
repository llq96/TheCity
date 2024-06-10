using TheCity.InGameTime;
using TMPro;
using UnityEngine;
using Zenject;

namespace TheCity
{
    public class GameTimeUI : MonoBehaviour
    {
        [Inject] private GameTime GameTime { get; }

        [SerializeField] private TextMeshProUGUI _tmp_date;
        [SerializeField] private TextMeshProUGUI _tmp_time;

        private void Update()
        {
            // UpdateTexts_AsLongDateAndTime();
            UpdateTexts_Custom();
        }

        private void UpdateTexts_Custom()
        {
            _tmp_date.text = GameTime.GameDateTime.ToString("dd.MM.yyyy");
            _tmp_time.text = GameTime.GameDateTime.ToString("HH:mm");
        }

        private void UpdateTexts_AsLongDateAndTime()
        {
            _tmp_date.text = GameTime.GameDateTime.ToLongDateString();
            _tmp_time.text = GameTime.GameDateTime.ToLongTimeString();
        }
    }
}