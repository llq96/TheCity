using UnityEngine;

namespace TheCity.Unity
{
    public class HomeRoomCitizenStuff : MonoBehaviour
    {
        [SerializeField] private Transform _sleepingPlace;

        public Transform SleepingPlace => _sleepingPlace;
    }
}