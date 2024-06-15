using System.Collections;
using System.Collections.Generic;

namespace TheCity.Utils
{
    public class ShuffledList<T> : IEnumerator<T>
    {
        private readonly List<T> _shuffledList;

        private int _index = -1;

        public ShuffledList(IEnumerable<T> enumerable)
        {
            _shuffledList = enumerable.GetShuffledCopy();
        }

        public bool MoveNext()
        {
            if (++_index >= _shuffledList.Count)
            {
                return false;
            }
            else
            {
                Current = _shuffledList[_index];
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
        }
    }
}