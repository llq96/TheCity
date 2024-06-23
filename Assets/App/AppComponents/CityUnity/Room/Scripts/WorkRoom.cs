using System.Collections.Generic;
using UnityEngine;

namespace TheCity.Unity
{
    public class WorkRoom : Room
    {
        [SerializeField] private List<JobPlace> _jobPlaces;

        public List<JobPlace> JobPlaces => _jobPlaces;
    }
}