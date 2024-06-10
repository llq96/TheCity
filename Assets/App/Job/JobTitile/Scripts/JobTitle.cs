using UnityEngine;

namespace TheCity
{
    [CreateAssetMenu(fileName = "JobTitle", menuName = "TheCity/Jobs/JobTitle", order = 1)]
    public class JobTitle : ScriptableObject
    {
        [SerializeField] private string _jobName;

        public override string ToString() => _jobName;
    }
}