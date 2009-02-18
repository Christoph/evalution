namespace Domain
{
    public interface ITextAnswer : IAnswer
    {
        int Id { get; set; }

        string Answer { get; set; }
    }
}