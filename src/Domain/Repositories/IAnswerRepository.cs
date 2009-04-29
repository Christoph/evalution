using System.Collections.Generic;

namespace Domain.Repositories
{
    public interface IAnswerRepository<T> : IRepository <T>
    {
        IEnumerable<T> CreateFor(Form form);
    }
}