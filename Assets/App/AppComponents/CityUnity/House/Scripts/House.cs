using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace TheCity.Unity
{
    public class House : MonoBehaviour
    {
        [Inject] public List<LivingRoom> LivingRooms { get; }
        [Inject] public List<WorkRoom> WorkRooms { get; }

        [field: SerializeField] public List<Transform> LivingRoomSpawnPoints { get; private set; }
        [field: SerializeField] public List<Transform> WorkRoomSpawnPoints { get; private set; }
    }
}