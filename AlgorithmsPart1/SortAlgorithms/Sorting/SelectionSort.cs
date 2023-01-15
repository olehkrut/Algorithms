namespace Sorting
{
    /// <summary>
    /// Complexity: ~N^2/2 comparisons, N swaps
    /// </summary>
    public static class SelectionSort
    {
        public static void Sort<T>(IList<T> list) where T : IComparable
            => Sort(list, (T a, T b) => a.CompareTo(b));

        public static void Sort<T>(IList<T> list, IComparer<T> comparer)
            => Sort(list, comparer.Compare);

        public static void Sort<T>(IList<T> list, Func<T, T, int> comparer)
        {
            for (int i = 0; i < list.Count; ++i)
            {
                var min = i;
                for (int j = i + 1; j < list.Count; ++j)
                    if (list[j].IsLessThan(list[min], comparer))
                        min = j;

                list.Swap(i, min);
            }
        }
    }
}