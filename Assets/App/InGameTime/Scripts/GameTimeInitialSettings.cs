using System;
using UnityEngine;

namespace TheCity
{
    [CreateAssetMenu(fileName = "GameTimeInitialSettings", menuName = "TheCity/GameTimeInitialSettings", order = 1)]
    public class GameTimeInitialSettings : ScriptableObject
    {
        [SerializeField] private SerializableDateTime _startDateTime;
        [SerializeField] private float _timeSpeedMultiplier = 60; //1 minute per 1 second

        public DateTime StartDateTime => _startDateTime.GetDateTime();
        public float TimeSpeedMultiplier => _timeSpeedMultiplier;


#if UNITY_INCLUDE_TESTS
        public SerializableDateTime Internal_StartDateTime
        {
            get => _startDateTime;
            set => _startDateTime = value;
        }

        public float Internal_TimeSpeedMultiplier
        {
            get => _timeSpeedMultiplier;
            set => _timeSpeedMultiplier = value;
        }
#endif
    }
}