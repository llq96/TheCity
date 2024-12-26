using System;
using JetBrains.Annotations;
using UniRx;
using UnityEngine;
using Zenject;

namespace TheCity.Unity
{
    [UsedImplicitly]
    public class GameTime : ITickable
    {
        private readonly IGameTimeInitialSettings _initialSettings;

        public ReactiveProperty<DateTime> GameDateTime { get; } = new();
        public ReactiveProperty<GameTimeType> GameTimeType { get; } = new(Unity.GameTimeType.FastPlay);

        [Inject]
        public GameTime(IGameTimeInitialSettings gameTimeInitialSettings)
        {
            _initialSettings = gameTimeInitialSettings;

            GameDateTime.Value = gameTimeInitialSettings.StartDateTime;
        }

        public void Tick()
        {
            var realDeltaTime = Time.deltaTime;
            var convertedDeltaTime = realDeltaTime * GetTimeSpeedMultiplier();
            GameDateTime.Value = GameDateTime.Value.AddSeconds(convertedDeltaTime);
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