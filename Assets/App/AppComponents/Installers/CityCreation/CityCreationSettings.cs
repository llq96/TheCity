using System;
using TheCity.Unity;
using UnityEngine;

namespace TheCity.Installers
{
    [Serializable]
    public class CityCreationSettings
    {
        [field: SerializeField] public GameObject CityPrefab { get; private set; }

        [field: SerializeField] public LivingRoom LivingRoomPrefab { get; private set; }
        [field: SerializeField] public WorkRoom WorkRoomPrefab { get; private set; }
    }
}