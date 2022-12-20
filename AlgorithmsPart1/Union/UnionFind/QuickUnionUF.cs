namespace UnionFind
{
    /// <summary>
    /// Quick union implementation.
    /// Find complexity: O(Nlog*N) in worst case scenario
    /// Union complexity: O(Nlog*N), because size of each tree can only double.
    /// log*N - iterative logarithm complexity - very small.
    /// </summary>
    public class QuickUnionUF : IUnionFind
    {
        private readonly int[] _store;
        private readonly int[] _weights;

        public QuickUnionUF(int size)
        {
            _store = new int[size];
            _weights = new int[size];

            foreach (int i in Enumerable.Range(0, size))
            {
                _store[i] = i;
                _weights[i] = 1;
            }
        }

        public int GetNumberOfConnectedSets()
            => _store.Where((el, i) => el == i).Count();

        public bool Connected(int first, int second)
            => GetRoot(first) == GetRoot(second);

        public void Union(int first, int second)
        {
            var firstElementRoot = GetRoot(first);
            var secondElementRoot = GetRoot(second);

            if (firstElementRoot == secondElementRoot)
                return;

            var firstRootWeight = _weights[firstElementRoot];
            var secondRootWeight = _weights[secondElementRoot];

            if (firstRootWeight < secondRootWeight)
            {
                _store[firstElementRoot] = secondElementRoot;
                _weights[secondElementRoot] += _weights[firstElementRoot];
            }
            else
            {
                _store[secondElementRoot] = firstElementRoot;
                _weights[firstElementRoot] += _weights[secondElementRoot];
            }
        }

        private int GetRoot(int el)
        {
            while (_store[el] != el)
            {
                _store[el] = _store[_store[el]]; // reducing tree depth by directly pointing to root
                el = _store[el];
            }

            return el;
        }
    }
}
