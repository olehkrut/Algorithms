using System.Collections;

namespace EzCollections.Stacks
{
    /// <summary>
    /// Defines stack data structure based on LinkedList.
    /// </summary>
    public class LinkedListBasedStack<T> : IEzStack<T>, IEnumerable<T>
    {
        private static readonly Node<T> NullNode = new Node<T>(default, null);
        private Node<T> _top = NullNode;
        private int _count = 0;

        public bool IsEmpty => _top == NullNode;
        public int Count => _count;

        public T Top
        {
            get
            {
                ThrowIfStackIsEmpty();

                return _top.Element;
            }
        }

        public void Push(T element)
        {
            _count++;
            var node = new Node<T>(element, _top);
            _top = node;
        }

        public T Pop()
        {
            ThrowIfStackIsEmpty();
            var top = Top;

            _count--;
            _top = _top.Next;

            return top;
        }

        public void Clear()
            => _top = NullNode;

        private void ThrowIfStackIsEmpty()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Stack is empty");
        }

        public IEnumerator<T> GetEnumerator()
        {
            var top = _top;
            while (top != NullNode)
            {
                yield return top.Element;
                top = top.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();

        private record Node<T>(T Element, Node<T> Next);
    }
}
