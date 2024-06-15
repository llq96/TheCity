using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using JetBrains.Annotations;
using Zenject;

namespace TheCity
{
    [UsedImplicitly]
    public class CitizensNamesGenerator
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
            return new CitizensNamesIEnumerator(
                PossibleFirstNames.GetShuffledCopy(),
                PossibleSecondNames.GetShuffledCopy()
            );
        }
    }

    public class CitizensNamesIEnumerator : IEnumerator<CitizenName>
    {
        private int _index = -1;
        private readonly List<string> _shuffledPossibleFirstNames;
        private readonly List<string> _shuffledPossibleSecondNames;

        private readonly int _maxCombinations;
        private readonly bool _isSameParity;

        private readonly int _possibleFirstNamesCount;
        private readonly int _possibleSecondNamesCount;

        public CitizensNamesIEnumerator(
            List<string> shuffledPossibleFirstNames,
            List<string> shuffledPossibleSecondNames)
        {
            _shuffledPossibleFirstNames = shuffledPossibleFirstNames;
            _shuffledPossibleSecondNames = shuffledPossibleSecondNames;

            _maxCombinations = _shuffledPossibleFirstNames.Count * _shuffledPossibleSecondNames.Count;

            _possibleFirstNamesCount = _shuffledPossibleFirstNames.Count;
            _possibleSecondNamesCount = _shuffledPossibleSecondNames.Count;

            _isSameParity = (_possibleFirstNamesCount % 2) == (_possibleSecondNamesCount % 2);
        }

        public bool MoveNext()
        {
            _index++;
            if (_index >= _maxCombinations) return false;

            var firstNameIndex = _index % _possibleFirstNamesCount;
            int secondNameIndex = _index % _possibleSecondNamesCount;
            if (_isSameParity)
            {
                secondNameIndex = (_index + (_index / _possibleFirstNamesCount)) % _possibleSecondNamesCount;
            }

            var firstName = _shuffledPossibleFirstNames[firstNameIndex];
            var secondName = _shuffledPossibleSecondNames[secondNameIndex];
            var citizenName = new CitizenName(firstName, secondName);

            Current = citizenName;
            return true;
        }

        public void Reset()
        {
            _index = -1;
        }

        public CitizenName Current { get; private set; }

        object IEnumerator.Current => Current;

        public void Dispose()
        {
        }
    }
}