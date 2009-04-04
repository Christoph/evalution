namespace Domain
{
    public interface ITextAnswer : IAnswer
    {
        int Id { get; }

        string Answer { get; set; }
    }
}