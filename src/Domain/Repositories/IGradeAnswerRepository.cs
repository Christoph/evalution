using System.Collections.Generic;
using Domain;

namespace Domain.Repositories
{
    public interface IGradeAnswerRepository : IRepository<IGradeAnswer>
    {
        IEnumerable<IGradeAnswer> CreateFor(IForm form, Stage stage);
    }
}