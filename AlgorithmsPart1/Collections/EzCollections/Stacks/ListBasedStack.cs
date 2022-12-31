using EzCollections.Lists;
using System.Collections;

namespace EzCollections.Stacks
{
    /// <summary>
    /// Defines Stack data structure based on the list.
    /// </summary>
    /// <typeparam name="T">Type of element.</typeparam>
    public class ListBasedStack<T> : IEzStack<T>, IEnumerable<T>
    {
        private readonly EzList<T> _stack = new();

        public T Top => _stack.Last();
        public bool IsEmpty => !_stack.Any();
        public int Count => _stack.Count;

        public void Push(T item) 
            => _stack.Add(item);

        public T Pop()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Stack is empty");

            var element = Top;
            _stack.RemoveAt(_stack.Count - 1);

            return element;
        }

        public void Clear()
            => _stack.Clear();

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in _stack.Reverse())
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();
    }
}
