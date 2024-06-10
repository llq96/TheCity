using System.Collections.Generic;
using UnityEngine;

namespace TheCity
{
    [CreateAssetMenu(fileName = "PossibleJobTitles", menuName = "TheCity/Jobs/PossibleJobTitles", order = 1)]
    public class PossibleJobTitles : ScriptableObject
    {
        [SerializeField] private List<JobTitle> _jobTitles;

        public List<JobTitle> JobTitles => _jobTitles;
    }
}