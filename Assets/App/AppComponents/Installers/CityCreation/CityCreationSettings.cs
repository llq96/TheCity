using System;
using TheCity.Unity;
using UnityEngine;

namespace TheCity.Installers
{
    [Serializable]
    public class CityCreationSettings
    {
        [field: SerializeField] public LivingRoom LivingRoomPrefab { get; private set; }
        [field: SerializeField] public WorkRoom WorkRoomPrefab { get; private set; }
        [field: SerializeField] public House HousePrefab { get; private set; }
    }
}