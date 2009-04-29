using System.Collections.Generic;

namespace Domain.Repositories
{
    public interface IBinaryAnswerRepository : IRepository<BinaryAnswer>
    {
        IEnumerable<BinaryAnswer> CreateFor(Form form);
    }
}