using System;

namespace TheCity
{
    public interface IGameTimeInitialSettings
    {
        public DateTime StartDateTime { get; }
        public float TimeSpeedMultiplier { get; }
    }
}