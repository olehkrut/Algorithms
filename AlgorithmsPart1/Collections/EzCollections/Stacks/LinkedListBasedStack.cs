namespace EzCollections.Stacks
{
    /// <summary>
    /// Defines stack data structure based on LinkedList.
    /// </summary>
    public class LinkedListBasedStack<T>
    {
        private static readonly Node<T> NullNode = new Node<T>(default, null);
        private Node<T> _top = NullNode;

        public bool IsEmpty => _top == NullNode;
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
            var node = new Node<T>(element, _top);
            _top = node;
        }

        public T Pop()
        {
            ThrowIfStackIsEmpty();
            var top = Top;

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

        private record Node<T>(T Element, Node<T> Next);
    }
}
