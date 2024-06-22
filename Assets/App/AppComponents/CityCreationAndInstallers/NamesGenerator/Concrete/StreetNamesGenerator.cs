using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using JetBrains.Annotations;
using TheCity.Utils;
using Zenject;

namespace TheCity
{
    [UsedImplicitly]
    [TestsInfo("StreetNamesGeneratorTests", 85)]
    public class StreetNamesGenerator : IStreetNamesGenerator
    {
        [Inject] private INamesGeneratorSettings Settings { get; }

        private IStreetPossibleNames StreetPossibleNames => Settings.StreetPossibleNames;
        private ReadOnlyCollection<string> StreetPossibleNamesStrings => StreetPossibleNames.Names;

        private IEnumerator<StreetName> _enumerator;

        public void Reset()
        {
            _enumerator = null;
        }

        public StreetName GetNextStreetName()
        {
            _enumerator ??= GetNewEnumerator();

            if (_enumerator.MoveNext())
            {
                return _enumerator.Current;
            }

            throw new Exception("End Collection");
        }

        private IEnumerator<StreetName> GetNewEnumerator()
        {
            var shuffledList = new ShuffledList<string>(StreetPossibleNamesStrings);

            foreach (var value in shuffledList)
            {
                yield return new StreetName(value);
            }
        }
    }
}