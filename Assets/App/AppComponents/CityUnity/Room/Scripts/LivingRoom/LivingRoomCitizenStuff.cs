using UnityEngine;

namespace TheCity.Unity
{
    public class LivingRoomCitizenStuff : MonoBehaviour
    {
        [SerializeField] private Transform _sleepingPlace;

        public Transform SleepingPlace => _sleepingPlace;
    }
}