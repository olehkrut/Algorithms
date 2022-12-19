namespace UnionFind
{
    /// <summary>
    /// Provides interface to work with UnionFind data structure implementations.
    /// https://www.wikiwand.com/en/Disjoint-set_data_structure
    /// </summary>
    public interface IUnionFind
    {
        /// <summary>
        /// Checks if two elements are connected in the union.
        /// </summary>
        /// <param name="first">The first element.</param>
        /// <param name="second">The second element.</param>
        /// <returns>Answer to your question.</returns>
        bool Connected(int first, int second);

        /// <summary>
        /// Makes two elements united(connected).
        /// </summary>
        /// <param name="first">The first element.</param>
        /// <param name="second">The second element.</param>
        void Union(int first, int second);
    }
}
