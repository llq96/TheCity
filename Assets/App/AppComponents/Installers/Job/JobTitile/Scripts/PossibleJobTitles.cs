using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using TheCity.CityDataGeneration;
using TheCity.Core;
using UnityEngine;

namespace TheCity.Installers
{
    [CreateAssetMenu(fileName = "PossibleJobTitles", menuName = "TheCity/Jobs/PossibleJobTitles", order = 1)]
    public class PossibleJobTitles : ScriptableObject, IPossibleJobTitles
    {
        [SerializeField] private List<JobTitle> _jobTitles;

        public ReadOnlyCollection<IJobTitle> JobTitles => _jobTitles.Cast<IJobTitle>().ToList().AsReadOnly();
    }
}