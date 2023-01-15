namespace Sorting
{
    public static class UtilityExtensions
    {
        public static void Swap<T>(this IList<T> collection, int i, int j)
        {
            var temp = collection[i];
            collection[i] = collection[j];
            collection[j] = temp;
        }

        public static bool IsLessThan<T>(this T a, T b, Func<T, T, int> comparer)
            => a.IsLessThan(b, new LambdaComparer<T>(comparer));

        public static bool IsLessThan<T>(this T a, T b, IComparer<T> comparer)
            => comparer.Compare(a, b) == -1;

        public static bool IsLessThan<T>(this T a, T b) where T : IComparable
            => a.CompareTo(b) == -1;
    }

    internal class LambdaComparer<T> : IComparer<T>
    {
        private readonly Func<T, T, int> _comparer;

        public LambdaComparer(Func<T, T, int> comparer)
        {
            _comparer = comparer;
        }

        public int Compare(T? x, T? y)
        {
            if (x is null) return -1;
            if (y is null) return 1;

            return _comparer(x, y);
        }
    }
}