namespace UnionFind
{
    /// <summary>
    /// Quick find implementation of Union Find
    /// Connected complexity: O(1)
    /// Union complexity: O(N)
    /// </summary>
    public class QuickFindUF : IUnionFind
    {
        private readonly int[] _store;

        public QuickFindUF(int size)
        {
            _store = Enumerable.Range(0, size).ToArray();
        }

        public int GetNumberOfConnectedSets()
            => _store.Distinct().Count();

        public bool Connected(int first, int second)
            => _store[first] == _store[second];

        public void Union(int first, int second)
        {
            if (Connected(first, second))
                return;

            var firstSetIndex = _store[first];
            var secondSetIndex = _store[second];

            for (var i = 0; i < _store.Length; ++i)
            {
                if (_store[i] == firstSetIndex)
                    _store[i] = secondSetIndex;
            }
        }
    }
}