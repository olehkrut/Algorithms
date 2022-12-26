using System.Collections;

namespace EzCollections.Lists
{
    /// <summary>
    /// It's a simple resizeable array implementation
    /// </summary>
    /// <typeparam name="T">element type.</typeparam>
    public class EzList<T> : IList<T>
    {
        private const int DefaultCapacity = 8;
        private const int CapacityMultiplier = 2;

        private T[] _arr;
        private int _count;

        public EzList() : this(DefaultCapacity)
        {
        }

        public EzList(int capacity)
        {
            _arr = new T[capacity];
        }

        public EzList(IEnumerable<T> collection) : this(DefaultCapacity)
        {
            foreach (var item in collection)
            {
                Add(item);
            }
        }

        public T this[int index]
        {
            get
            {
                EnsureIndexIsInRange(index);

                return _arr[index];
            }
            set
            {
                EnsureIndexIsInRange(index);

                _arr[index] = value;
            }
        }

        public int Count => _count;
        public int Capacity => _arr.Length;
        public bool IsReadOnly { get; } = false;

        public int IndexOf(T item)
        {
            for (int i = 0; i < _count; i++)
            {
                if (Equals(_arr[i], item))
                    return i;
            }

            return -1;
        }

        public void Insert(int index, T item)
        {
            EnsureIndexIsInRange(index);
            var count = _count++;
            IncreaseArrayCapacityIfNeeded();

            for (int i = _count; i > index; --i)
            {
                _arr[i] = _arr[i - 1];
            }

            _arr[index] = item;
        }

        public void RemoveAt(int index)
        {
            EnsureIndexIsInRange(index);

            for (int i = index; i < _count - 1; i++)
            {
                _arr[i] = _arr[i + 1];
            }

            _count--;
        }

        public void Add(T item)
        {
            IncreaseArrayCapacityIfNeeded();

            _arr[_count++] = item;
        }

        public void Clear()
        {
            for (int i = 0; i < _count; i++)
            {
                _arr[i] = default;
            }

            _count = 0;
        }

        public bool Contains(T item)
            => _arr.Contains(item);

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            var index = IndexOf(item);

            if (index != -1)
            {
                RemoveAt(index);
                return true;
            }
            else
            {
                return false;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return _arr[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();

        private void EnsureIndexIsInRange(int index)
        {
            if (index >= _count || index < 0)
                throw new IndexOutOfRangeException($"Index is out of range. Info: {(index, _count)}");
        }

        private void IncreaseArrayCapacityIfNeeded()
        {
            if (_count < _arr.Length)
                return;

            var newArr = new T[_arr.Length * CapacityMultiplier];
            _arr.CopyTo(newArr, 0);

            _arr = newArr;
        }
    }
}
