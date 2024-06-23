using UnityEngine;

namespace TheCity.Unity
{
    public class JobPlace : MonoBehaviour
    {
        [SerializeField] private Transform _seatPlace;

        public Transform SeatPlace => _seatPlace;
    }
}