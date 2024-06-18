using System;
using UnityEngine;
using UnityEngine.TestTools;

namespace TheCity
{
    public interface IGameTimeInitialSettings
    {
        public DateTime StartDateTime { get; }
        public float TimeSpeedMultiplier { get; }
    }

    [CreateAssetMenu(fileName = "GameTimeInitialSettings", menuName = "TheCity/GameTimeInitialSettings", order = 1)]
    [ExcludeFromCoverage]
    public class GameTimeInitialSettings : ScriptableObject, IGameTimeInitialSettings
    {
        [SerializeField] private SerializableDateTime _startDateTime;
        [SerializeField] private float _timeSpeedMultiplier = 60; //1 minute per 1 second

        public DateTime StartDateTime => _startDateTime.GetDateTime();
        public float TimeSpeedMultiplier => _timeSpeedMultiplier;
    }
}