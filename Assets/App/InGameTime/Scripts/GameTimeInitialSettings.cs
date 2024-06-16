using System;
using UnityEngine;

namespace TheCity
{
    public interface IGameTimeInitialSettings
    {
        public DateTime StartDateTime { get; }
        public float TimeSpeedMultiplier { get; }
    }

    [CreateAssetMenu(fileName = "GameTimeInitialSettings", menuName = "TheCity/GameTimeInitialSettings", order = 1)]
    [TestsInfo(100)]
    public class GameTimeInitialSettings : ScriptableObject, IGameTimeInitialSettings
    {
        [SerializeField] private SerializableDateTime _startDateTime;
        [SerializeField] private float _timeSpeedMultiplier = 60; //1 minute per 1 second

        public DateTime StartDateTime => _startDateTime.GetDateTime();
        public float TimeSpeedMultiplier => _timeSpeedMultiplier;
    }
}