namespace UnionFind
{
    /// <summary>
    /// Quick union implementation.
    /// Find complexity: O(N) in worst case scenario
    /// Union complexity: O(N) in worst case scenario
    /// </summary>
    public class QuickUnionUF : IUnionFind
    {
        private readonly int[] _store;

        public QuickUnionUF(int size)
        {
            _store = Enumerable.Range(0, size).ToArray();
        }

        public int GetNumberOfConnectedSets()
            => _store.Where((el, i) => el == i).Count();

        public bool Connected(int first, int second)
            => GetRoot(first) == GetRoot(second);

        public void Union(int first, int second)
        {
            var firstElementRoot = GetRoot(first);
            var secondElementRoot = GetRoot(second);

            _store[firstElementRoot] = secondElementRoot;
        }

        private int GetRoot(int child)
        {
            var root = _store[child];

            while (_store[root] != root)
                root = _store[root];

            return root;
        }
    }
}
