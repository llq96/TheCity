using System;

namespace TheCity.Unity
{
    public interface IGameTimeInitialSettings
    {
        public DateTime StartDateTime { get; }
        public float TimeSpeedMultiplier { get; }
    }
}