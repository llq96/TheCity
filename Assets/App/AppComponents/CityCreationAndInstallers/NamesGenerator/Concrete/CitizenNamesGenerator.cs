using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using JetBrains.Annotations;
using TheCity.Utils;
using Zenject;

namespace TheCity
{
    [UsedImplicitly]
    [TestsInfo("CitizenNamesGeneratorTests", 86)]
    public class CitizenNamesGenerator : ICitizenNamesGenerator
    {
        [Inject] private INamesGeneratorSettings Settings { get; }

        private ICitizenPossibleNames CitizenPossibleNames => Settings.CitizenPossibleNames;
        private ReadOnlyCollection<string> PossibleFirstNames => CitizenPossibleNames.FirstNames;
        private ReadOnlyCollection<string> PossibleSecondNames => CitizenPossibleNames.SecondNames;

        private IEnumerator<CitizenName> _enumerator;

        public void Reset()
        {
            _enumerator = null;
        }

        public CitizenName GetNextCitizenName()
        {
            _enumerator ??= GetNewEnumerator();

            if (_enumerator.MoveNext())
            {
                return _enumerator.Current;
            }

            throw new Exception("End Collection");
        }

        private IEnumerator<CitizenName> GetNewEnumerator()
        {
            var shuffledList = new WrappedShuffledList<string, string, CitizenName>(
                PossibleFirstNames,
                PossibleSecondNames,
                (firstName, secondName) => new CitizenName(firstName, secondName)
            );

            foreach (var value in shuffledList)
            {
                yield return value;
            }
        }
    }
}