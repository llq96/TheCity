using UnityEngine;

namespace TheCity
{
    public class Room : MonoBehaviour
    {
        public AddressData AddressData { get; private set; }

        public void Construct(AddressData addressData) //TODO via Inject
        {
            AddressData = addressData;
        }

        public override string ToString() => AddressData.ToString();
    }
}