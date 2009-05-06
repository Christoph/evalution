namespace Domain.Repositories
{
    public interface IAnswerRepository<T> : IRepository<T>
    {
        void CreateFor(Form form);
    }
}