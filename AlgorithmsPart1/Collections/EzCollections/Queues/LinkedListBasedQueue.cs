using System.Collections;

namespace EzCollections.Queues
{
    public class LinkedListBasedQueue<T> : IEnumerable<T>
    {
        private static readonly Node<T> NullNode = new Node<T>(default, null);

        private Node<T> _first = NullNode;
        private Node<T> _last = NullNode;
        private int _count = 0;

        public bool IsEmpty => _first == NullNode;
        public int Count => _count;

        public T First
        {
            get
            {
                ThrowIfQueueIsEmpty();

                return _first.Element;
            }
        }

        public T Last
        {
            get
            {
                ThrowIfQueueIsEmpty();

                return _last.Element;
            }
        }

        public void Enqueue(T element)
        {
            var node = new Node<T>(element, NullNode);

            if (IsEmpty)
            {
                _first = _last = node;
                return;
            }

            _last.Next = node;
            _last = node;
            _count++;
        }

        public T Dequeue()
        {
            ThrowIfQueueIsEmpty();

            var value = _first.Element;

            _first = _first.Next;

            return value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var iterator = _first;

            while(iterator != NullNode)
            {
                yield return iterator.Element;
                iterator = iterator.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();

        private void ThrowIfQueueIsEmpty()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Queue is empty.");
        }

        private record Node<T>
        {
            public Node(T element, Node<T> next)
            {
                Element = element;
                Next = next;
            }

            public T Element { get; }
            public Node<T> Next { get; set; }
        }
    }
}
