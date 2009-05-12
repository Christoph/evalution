namespace Domain.Repositories
{
    public interface IQuestionFormRepository : IRepository<Form>
    {
        Form GetPreviousForm(int id);

        Form GetNextForm(int id);

        bool HasPrevious(int id);

        bool HasNext(int id);

        int GetNextId();

        Form GetLast();
    }
}