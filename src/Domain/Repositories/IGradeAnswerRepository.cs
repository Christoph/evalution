using System.Collections.Generic;

namespace Domain.Repositories
{
    public interface IGradeAnswerRepository : IRepository<GradeAnswer>
    {
        IEnumerable<GradeAnswer> CreateFor(Form form, Stage stage);
    }
}