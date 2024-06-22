using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TheCity.Installers;

namespace TheCity.Utils
{
    /// <summary>
    /// Позволяет перечислять уникальные составные объекты,
    /// Например все возможные комбинации Имя+Фамилия из двух соответствующих списков, преобразованные в объект TOut
    /// </summary>
    public class WrappedShuffledList<T1, T2, TOut> : ShuffledList<T1, T2>, IEnumerable<TOut>
    {
        private readonly Func<T1, T2, TOut> _selector;

        public WrappedShuffledList(IEnumerable<T1> enumerable, IEnumerable<T2> enumerable2, Func<T1, T2, TOut> selector)
            : base(enumerable, enumerable2)
        {
            _selector = selector;
        }

        public new IEnumerator<TOut> GetEnumerator()
        {
            var innerEnumerator = ((IEnumerable<Tuple<T1, T2>>)this);

            foreach (var tuple in innerEnumerator)
            {
                yield return _selector(tuple.Item1, tuple.Item2);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class ShuffledList<T1, T2> : IEnumerable<Tuple<T1, T2>>
    {
        private readonly List<T1> _list1;
        private readonly List<T2> _list2;

        public ShuffledList(IEnumerable<T1> enumerable, IEnumerable<T2> enumerable2)
        {
            _list1 = enumerable.ToList();
            _list2 = enumerable2.ToList();
        }

        public IEnumerator<Tuple<T1, T2>> GetEnumerator()
        {
            return new ShuffledListEnumerator<T1, T2>(_list1, _list2);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class ShuffledListEnumerator<T1, T2> : IEnumerator<Tuple<T1, T2>>
    {
        private readonly List<T1> _list1;
        private readonly List<T2> _list2;

        private readonly int _maxCombinations;
        private readonly bool _isSameParity;

        private readonly int _list1_count;
        private readonly int _list2_count;

        private int _index = -1;

        public ShuffledListEnumerator(IEnumerable<T1> enumerable, IEnumerable<T2> enumerable2)
        {
            _list1 = enumerable.GetShuffledCopy();
            _list2 = enumerable2.GetShuffledCopy();
            _maxCombinations = _list1.Count * _list2.Count;

            _list1_count = _list1.Count;
            _list2_count = _list2.Count;

            _isSameParity = (_list1_count % 2) == (_list2_count % 2);
        }

        public bool MoveNext()
        {
            _index++;
            if (_index >= _maxCombinations) return false;

            var index1 = _index % _list1_count;

            var index2 = ((_index % _list1_count) + (_index / _list1_count)) % _list2_count;

            var element1 = _list1[index1];
            var element2 = _list2[index2];
            Current = new Tuple<T1, T2>(element1, element2);

            return true;
        }

        public void Reset()
        {
            _index = -1;
        }

        public Tuple<T1, T2> Current { get; private set; }

        object IEnumerator.Current => Current;

        public void Dispose()
        {
            _list1.Clear();
            _list1.TrimExcess();
            _list2.Clear();
            _list2.TrimExcess();
        }
    }
}