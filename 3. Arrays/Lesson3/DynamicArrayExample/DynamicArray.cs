using System.Collections;

namespace DenamicArrayProject
{
    internal class DynamicArray<T> : IEnumerable<T>
    {
        private T[] _items = new T[8];

        private int _lastIndex = 0;

        public void Add(T item)
        {
            int nextIndex = _lastIndex + 1;

            if (nextIndex == _items.Length)
            {
                T[] resizedArr = new T[_items.Length * 2];
                Array.Copy(_items, resizedArr, _items.Length);
                _items = resizedArr;
            }

            _lastIndex = nextIndex;
            _items[_lastIndex] = item;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)_items).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _items.GetEnumerator();
        }
    }
}