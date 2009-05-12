namespace Domain.Repositories
{
    public interface IRepository<T>
    {
        void Insert(T item);
    }
}