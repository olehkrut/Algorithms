using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    public static class SortAlgorithms
    {
        public static void SelectionSort<T>(IList<T> list) where T : IComparable
            => SelectionSort(list, (T a, T b) => a.CompareTo(b));

        public static void SelectionSort<T>(IList<T> list, IComparer<T> comparer)
            => SelectionSort(list, comparer.Compare);

        /// <summary>
        /// Complexity: ~N^2/2 comparisons
        /// </summary>
        public static void SelectionSort<T>(IList<T> list, Func<T, T, int> comparer)
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
