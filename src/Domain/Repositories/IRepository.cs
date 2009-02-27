using System.Collections.Generic;

namespace TheNewEngine.Datalayer
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();

        void Insert(T item);
    }
}