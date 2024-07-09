using System.Collections.Generic;
using UnityEngine;

namespace TheCity.Unity
{
    public class House : MonoBehaviour
    {
        [field: SerializeField] public List<Transform> LivingRoomSpawnPoints { get; private set; }
        [field: SerializeField] public List<Transform> WorkRoomSpawnPoints { get; private set; }
    }
}