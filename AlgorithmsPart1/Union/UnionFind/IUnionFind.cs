namespace UnionFind
{
    public interface IUnionFind
    {
        bool Connected(int first, int second);

        void Union(int first, int second);
    }
}
