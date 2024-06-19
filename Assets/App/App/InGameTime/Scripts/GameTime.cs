using System;
using JetBrains.Annotations;
using UnityEngine;
using Zenject;

namespace TheCity.InGameTime
{
    [UsedImplicitly]
    [TestsInfo("BaseGameTimeTests", 100)]
    public class GameTime : ITickable
    {
        public DateTime GameDateTime { get; private set; }

        private readonly IGameTimeInitialSettings _initialSettings;

        [Inject]
        public GameTime(IGameTimeInitialSettings gameTimeInitialSettings)
        {
            _initialSettings = gameTimeInitialSettings;

            GameDateTime = gameTimeInitialSettings.StartDateTime;
        }

        public void Tick()
        {
            var realDeltaTime = Time.deltaTime;
            var convertedDeltaTime = realDeltaTime * _initialSettings.TimeSpeedMultiplier;
            GameDateTime = GameDateTime.AddSeconds(convertedDeltaTime);
        }
    }
}