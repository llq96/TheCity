using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

namespace TheCity.Unity
{
    public class LivingRoom : Room
    {
        [SerializeField] private List<HomeRoomCitizenStuff> _citizenStuffs;

        public ReadOnlyCollection<HomeRoomCitizenStuff> CitizenStuffs => _citizenStuffs.AsReadOnly();
    }
}