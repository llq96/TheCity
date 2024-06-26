using System;
using TheCity.Unity;
using UnityEngine;

namespace TheCity.Installers
{
    [CreateAssetMenu(fileName = "GameTimeInitialSettings", menuName = "TheCity/GameTimeInitialSettings", order = 1)]
    public class GameTimeInitialSettings : ScriptableObject, IGameTimeInitialSettings
    {
        [SerializeField] private SerializableDateTime _startDateTime;
        [SerializeField] private float _timeSpeedMultiplier = 60; //1 minute per 1 second

        public DateTime StartDateTime => _startDateTime.GetDateTime();
        public float TimeSpeedMultiplier => _timeSpeedMultiplier;
    }
}