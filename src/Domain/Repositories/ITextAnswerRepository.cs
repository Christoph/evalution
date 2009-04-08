using System.Collections.Generic;
using Domain;
using Domain.Repositories;

namespace Domain.Repositories
{
    public interface ITextAnswerRepository : IRepository<ITextAnswer>
    {
        IEnumerable<ITextAnswer> CreateFor(IForm form, Stage stage);
    }
}