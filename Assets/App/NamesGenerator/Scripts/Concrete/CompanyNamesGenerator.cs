using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using JetBrains.Annotations;
using TheCity.Utils;
using Zenject;

namespace TheCity
{
    [UsedImplicitly]
    public class CompanyNamesGenerator
    {
        [Inject] private INamesGeneratorSettings Settings { get; }

        private ICompanyPossibleNames CompanyPossibleNames => Settings.CompanyPossibleNames;
        private ReadOnlyCollection<string> PossibleNames => CompanyPossibleNames.Names;
        private ReadOnlyCollection<string> PossibleTypes => CompanyPossibleNames.Types;

        private IEnumerator<CompanyName> _enumerator;

        public void Reset()
        {
            _enumerator = null;
        }

        public CompanyName GetNextCompanyName()
        {
            _enumerator ??= GetNewEnumerator();

            if (_enumerator.MoveNext())
            {
                return _enumerator.Current;
            }

            throw new Exception("End Collection");
        }

        private IEnumerator<CompanyName> GetNewEnumerator()
        {
            var shuffledList = new ShuffledList<string>(PossibleNames);

            foreach (var value in shuffledList)
            {
                var companyType = PossibleTypes.GetRandomElement();
                yield return new CompanyName(value, companyType);
            }
        }
    }
}