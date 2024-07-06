using System;
using JetBrains.Annotations;
using UnityEngine;
using Zenject;

namespace TheCity.Unity
{
    [UsedImplicitly]
    public class GameTime : ITickable
    {
        public DateTime GameDateTime { get; private set; }

        private readonly IGameTimeInitialSettings _initialSettings;

        public GameTimeType GameTimeType { get; set; } = GameTimeType.Play;

        [Inject]
        public GameTime(IGameTimeInitialSettings gameTimeInitialSettings)
        {
            _initialSettings = gameTimeInitialSettings;

            GameDateTime = gameTimeInitialSettings.StartDateTime;
        }

        public void Tick()
        {
            var realDeltaTime = Time.deltaTime;
            var convertedDeltaTime = realDeltaTime * GetTimeSpeedMultiplier();
            GameDateTime = GameDateTime.AddSeconds(convertedDeltaTime);
        }

        public float GetTimeSpeedMultiplier()
        {
            return _initialSettings.GetTimeSpeedMultiplier(GameTimeType);
        }
    }

    public enum GameTimeType
    {
        Pause,
        Play,
        FastPlay,
        VeryFastPlay
    }
}