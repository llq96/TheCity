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


        #region Private Serializable Field Names

        public const string Name_Of_StartDateTime = nameof(_startDateTime);
        public const string Name_Of_TimeSpeedMultiplier = nameof(_timeSpeedMultiplier);

        #endregion
    }
}