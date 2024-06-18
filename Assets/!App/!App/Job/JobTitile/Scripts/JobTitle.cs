using UnityEngine;
using UnityEngine.TestTools;

namespace TheCity
{
    public interface IJobTitle
    {
        public string JobName { get; }
    }

    [CreateAssetMenu(fileName = "JobTitle", menuName = "TheCity/Jobs/JobTitle", order = 1)]
    [ExcludeFromCoverage]
    public class JobTitle : ScriptableObject, IJobTitle
    {
        [SerializeField] private string _jobName;

        public string JobName => _jobName;
        public override string ToString() => _jobName;
    }
}