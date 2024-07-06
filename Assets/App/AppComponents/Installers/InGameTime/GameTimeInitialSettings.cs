using System;
using TheCity.Unity;
using UnityEngine;

namespace TheCity.Installers
{
    [CreateAssetMenu(fileName = "GameTimeInitialSettings", menuName = "TheCity/GameTimeInitialSettings", order = 1)]
    public class GameTimeInitialSettings : ScriptableObject, IGameTimeInitialSettings
    {
        [SerializeField] private SerializableDateTime _startDateTime;

        [Header("Multipliers By Type")]
        [SerializeField] private float _multiplier_pause = 0;
        [SerializeField] private float _multiplier_play = 1;
        [SerializeField] private float _multiplier_fastPlay = 10;
        [SerializeField] private float _multiplier_veryFastPlay = 100;

        public DateTime StartDateTime => _startDateTime.GetDateTime();

        public float GetTimeSpeedMultiplier(GameTimeType gameTimeType)
        {
            return gameTimeType switch
            {
                GameTimeType.Pause => _multiplier_pause,
                GameTimeType.Play => _multiplier_play,
                GameTimeType.FastPlay => _multiplier_fastPlay,
                GameTimeType.VeryFastPlay => _multiplier_veryFastPlay,
                _ => throw new ArgumentOutOfRangeException(nameof(gameTimeType), gameTimeType, null)
            };
        }
    }
}