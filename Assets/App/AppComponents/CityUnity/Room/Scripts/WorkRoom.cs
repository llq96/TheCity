using System.Collections.Generic;
using UnityEngine;

namespace TheCity.Unity
{
    public class WorkRoom : Room
    {
        [SerializeField] private List<Transform> _jobPostsPlaces;

        public List<Transform> JobPostsPlaces => _jobPostsPlaces;
    }
}