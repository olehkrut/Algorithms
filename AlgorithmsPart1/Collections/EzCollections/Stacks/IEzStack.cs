namespace EzCollections.Stacks
{
    /// <summary>
    /// Defines ez stack API.
    /// </summary>
    /// <typeparam name="T">Type of element.</typeparam>
    public interface IEzStack<T>
    {
        bool IsEmpty { get; }
        int Count { get; }
        T Top { get; }

        void Push(T item);
        T Pop();
        void Clear();
    }
}
