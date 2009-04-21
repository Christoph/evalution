using System.Collections.Generic;

namespace Domain.Repositories
{
    public interface ITextAnswerRepository : IRepository<TextAnswer>
    {
        IEnumerable<TextAnswer> CreateFor(Form form, Stage stage);
    }
}