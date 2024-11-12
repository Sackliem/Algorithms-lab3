namespace algLab_3.Lists
{
    public interface ICollection<T> : IEnumerable<T>
    {
        void Add(T item);
        void Delete(T item);
        void Clear();
    }
}
