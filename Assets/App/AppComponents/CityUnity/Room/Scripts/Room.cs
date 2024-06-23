using TheCity.Core;
using UnityEngine;
using Zenject;

namespace TheCity.Unity
{
    public class Room : MonoBehaviour
    {
        [InjectOptional] public AddressData AddressData { get; private set; }

        public override string ToString() => AddressData.ToString();
    }
}