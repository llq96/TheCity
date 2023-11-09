using UnityEngine;

namespace TheCity
{
    public class City : MonoBehaviour
    {
        [SerializeField] private Transform _citizensParent;

        public Transform CitizensParent => _citizensParent;
    }
}