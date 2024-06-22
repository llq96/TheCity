using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TheCity.Installers;

namespace TheCity.Utils
{
    public class ShuffledList<T1> : IEnumerable<T1>
    {
        private readonly List<T1> _list;

        public ShuffledList(IEnumerable<T1> enumerable)
        {
            _list = enumerable.ToList();
        }

        public IEnumerator<T1> GetEnumerator()
        {
            return new ShuffledListEnumerator<T1>(_list);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class ShuffledListEnumerator<T> : IEnumerator<T>
    {
        private readonly List<T> _list;

        private int _index = -1;

        public ShuffledListEnumerator(IEnumerable<T> enumerable)
        {
            _list = enumerable.GetShuffledCopy();
        }

        public bool MoveNext()
        {
            if (++_index >= _list.Count)
            {
                return false;
            }
            else
            {
                Current = _list[_index];
                return true;
            }
        }

        public void Reset()
        {
            _index = -1;
        }

        public T Current { get; private set; }

        object IEnumerator.Current => Current;

        public void Dispose()
        {
            _list.Clear();
            _list.TrimExcess();
        }
    }
}