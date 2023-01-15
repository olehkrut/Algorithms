namespace Sorting
{
    /// <summary>
    /// Complexity: N^2/4 comparisons, N^2/4 swaps
    /// Benefit: linear time in partially sorted collections.
    /// </summary>
    public static class InsertionSort
    {
        public static void Sort<T>(IList<T> list) where T : IComparable
            => Sort(list, (T a, T b) => a.CompareTo(b));

        public static void Sort<T>(IList<T> list, IComparer<T> comparer)
            => Sort(list, comparer.Compare);

        public static void Sort<T>(IList<T> list, Func<T, T, int> comparer)
        {
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = i - 1; j >= 0; j--)
                    if (list[j + 1].IsLessThan(list[j], comparer))
                        list.Swap(j, j + 1);
                    else break;
            }
        }
    }
}
