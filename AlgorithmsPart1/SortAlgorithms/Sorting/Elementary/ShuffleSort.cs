namespace Sorting.Elementary
{
    /// <summary>
    /// Shuffles a given collection.
    /// Complexity: N.
    /// </summary>
    public static class ShuffleSort
    {
        public static void Shuffle<T>(IList<T> list)
        {
            for (int i = 1; i < list.Count; i++)
            {
                var random = new Random();
                list.Swap(i, random.Next(i + 1));
            }
        }
    }
}
