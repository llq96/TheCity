using System;
using TMPro;
using UniRx;
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

        private void Awake()
        {
            GameTime.GameTimeType.Subscribe(UpdateTimeMultiplier);
            GameTime.GameDateTime.Subscribe(UpdateTexts_Custom);
        }

        private void UpdateTimeMultiplier(GameTimeType type)
        {
            var text = GetTextByType();

            _tmp_timeSpeedMultiplier.text = $"{text}";

            return;

            string GetTextByType()
            {
                return type switch
                {
                    GameTimeType.Pause => "||",
                    GameTimeType.Play => ">",
                    GameTimeType.FastPlay => ">>",
                    GameTimeType.VeryFastPlay => ">>>",
                    _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
                };
            }
        }

        private void UpdateTexts_Custom(DateTime dateTime)
        {
            _tmp_date.text = dateTime.ToString("dd.MM.yyyy ddd");
            _tmp_time.text = dateTime.ToString("HH:mm");
        }

        private void UpdateTexts_AsLongDateAndTime(DateTime dateTime)
        {
            _tmp_date.text = dateTime.ToLongDateString();
            _tmp_time.text = dateTime.ToLongTimeString();
        }
    }
}