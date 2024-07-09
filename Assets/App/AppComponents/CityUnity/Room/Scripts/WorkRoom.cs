using System.Collections.Generic;
using System.Linq;
using TheCity.Core;
using UnityEngine;

namespace TheCity.Unity
{
    public class WorkRoom : Room
    {
        [SerializeField] private List<JobPlace> _jobPlaces;

        public List<JobPlace> JobPlaces => _jobPlaces;

        public JobPlace GetJobPlace(JobPost jobPost)
        {
            return _jobPlaces.First(x => x.JobPost == jobPost);
        }
    }
}