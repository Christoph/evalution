using System.Collections.Generic;
using Domain;

namespace Domain.Repositories
{
    public interface IBinaryAnswerRepository : IRepository<IBinaryAnswer>
    {
        IEnumerable<IBinaryAnswer> CreateFor(IForm form, Stage stage);
    }
}