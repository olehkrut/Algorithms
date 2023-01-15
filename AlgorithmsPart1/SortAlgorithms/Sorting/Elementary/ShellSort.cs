namespace Sorting.Elementary
{
    /// <summary>
    /// Complexity: N^(3/2)
    /// In reality is much faster as it makes partially sorted collection.
    /// And then applies Insertion sort which has linear complexity for such collections.
    /// </summary>
    public static class ShellSort
    {
        public static void Sort<T>(IList<T> list) where T : IComparable
            => Sort(list, (a, b) => a.CompareTo(b));

        public static void Sort<T>(IList<T> list, IComparer<T> comparer)
            => Sort(list, comparer.Compare);

        public static void Sort<T>(IList<T> list, Func<T, T, int> comparer)
        {
            var h = 1;

            while (h < list.Count)
                h = 3 * h + 1;

            while (h >= 1)
            {
                for (int i = h; i < list.Count; i += h)
                {
                    for (int j = i; j >= h; j -= h)
                        if (list[j].IsLessThan(list[j - h], comparer))
                            list.Swap(j, j - h);
                        else break;
                }

                h /= 3;
            }
        }
    }
}
