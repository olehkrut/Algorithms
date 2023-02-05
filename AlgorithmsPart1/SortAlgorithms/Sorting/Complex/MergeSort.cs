using System.Diagnostics;
using System.Diagnostics.Contracts;

namespace Sorting.Complex
{
    public class MergeSort
    {
        public static void Sort<T>(IList<T> list) where T : IComparable
            => Sort(list, (a, b) => a.CompareTo(b));

        public static void Sort<T>(IList<T> list, IComparer<T> comparer)
            => Sort(list, comparer.Compare);

        public static void Sort<T>(IList<T> list, Func<T, T, int> comparer)
        {
            var auxiliry = new T[list.Count];

            Sort(list, auxiliry, 0, list.Count - 1, comparer);
        }

        private static void Sort<T>(IList<T> original, IList<T> auxiliry, int low, int high, Func<T, T, int> comparer)
        {
            if (high <= low)
            {
                return;
            }

            int mid = (low + high) / 2;

            Sort(original, auxiliry, low, mid, comparer);
            Sort(original, auxiliry, mid + 1, high, comparer);

            Merge(original, auxiliry, low, mid, high, comparer);
        }



        public static void Merge<T>(IList<T> original, IList<T> auxilary, int low, int mid, int high, Func<T, T, int> comparer)
        {
            for (int k = low; k <= high; k++)
            {
                auxilary[k] = original[k];
            }

            int i = low;
            int j = mid + 1;

            for (int k = low; k <= high; k++)
            {
                if (i > mid)
                {
                    original[k] = auxilary[j++];
                }
                else if (j > high)
                {
                    original[k] = auxilary[i++];
                }
                else if (auxilary[i].IsLessThan(auxilary[j], comparer))
                {
                    original[k] = auxilary[i++];
                }
                else
                {
                    original[k] = auxilary[j++];
                }
            }
        }
    }
}
