using UnityEngine;
using UnityEngine.TestTools;

namespace TheCity
{
    [CreateAssetMenu(fileName = "JobTitle", menuName = "TheCity/Jobs/JobTitle", order = 1)]
    
    public class JobTitle : ScriptableObject, IJobTitle
    {
        [SerializeField] private string _jobName;

        public string JobName => _jobName;
        public override string ToString() => _jobName;
    }
}