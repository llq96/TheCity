using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

namespace TheCity.Unity
{
    public class LivingRoom : Room
    {
        [SerializeField] private List<LivingRoomCitizenStuff> _citizenStuffs;

        public ReadOnlyCollection<LivingRoomCitizenStuff> CitizenStuffs => _citizenStuffs.AsReadOnly();
    }
}