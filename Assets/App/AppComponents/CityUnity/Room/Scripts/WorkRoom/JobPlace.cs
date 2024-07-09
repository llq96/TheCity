using TheCity.Core;
using UnityEngine;
using Zenject;

namespace TheCity.Unity
{
    public class JobPlace : MonoBehaviour
    {
        [InjectOptional] public JobPost JobPost { get; }

        [SerializeField] private Transform _seatPlace;

        public Transform SeatPlace => _seatPlace;
    }
}