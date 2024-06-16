using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using UnityEngine;

namespace TheCity
{
    public interface IPossibleJobTitles
    {
        ReadOnlyCollection<IJobTitle> JobTitles { get; }
    }

    [CreateAssetMenu(fileName = "PossibleJobTitles", menuName = "TheCity/Jobs/PossibleJobTitles", order = 1)]
    public class PossibleJobTitles : ScriptableObject, IPossibleJobTitles
    {
        [SerializeField] private List<JobTitle> _jobTitles;

        public ReadOnlyCollection<IJobTitle> JobTitles => _jobTitles.Cast<IJobTitle>().ToList().AsReadOnly();
    }
}