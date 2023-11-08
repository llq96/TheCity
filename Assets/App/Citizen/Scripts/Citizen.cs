using UnityEngine;
using Zenject;

namespace TheCity
{
    public class Citizen : MonoBehaviour
    {
        [Inject] private CitizenInbornData InbornData { get; }

        private void Start()
        {
            Debug.Log($"{InbornData.FirstName} {InbornData.SecondName}");
        }
    }
}