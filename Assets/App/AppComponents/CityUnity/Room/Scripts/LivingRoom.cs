using UnityEngine;

namespace TheCity.Unity
{
    public class LivingRoom : Room
    {
        [SerializeField] private Transform _sleepingPlace;

        public Transform SleepingPlace => _sleepingPlace;
    }
}