using System.Collections.Generic;

namespace Domain.Repositories
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();

        void Insert(T item);
    }
}