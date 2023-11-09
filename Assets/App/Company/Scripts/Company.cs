using UnityEngine;
using Zenject;

namespace TheCity
{
    public class Company : MonoBehaviour
    {
        [Inject] private CompanyData CompanyData { get; }
        [Inject] public Room Room { get; }

        private void Start()
        {
            Debug.Log(Room);
        }
    }
}