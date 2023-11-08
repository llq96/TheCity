using JetBrains.Annotations;
using UnityEngine;
using Zenject;

namespace TheCity
{
    [UsedImplicitly]
    public class NamesGenerator
    {
        [Inject] private NamesGeneratorSettings Settings { get; }

        public void GenerateRandomName(out string firstName, out string secondName)
        {
            var firstNames = Settings.NamesLists.FirstNames;
            var secondNames = Settings.NamesLists.SecondNames;

            firstName = firstNames[Random.Range(0, firstNames.Count)];
            secondName = secondNames[Random.Range(0, secondNames.Count)];
        }
    }
}