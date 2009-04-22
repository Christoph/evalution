namespace Domain.Repositories
{
    public interface IQuestionFormRepository : IRepository<Form>
    {
        Form GetPreviousForm(int id);

        Form GetNextForm(int id);
    }
}