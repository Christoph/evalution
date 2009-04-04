namespace Domain
{
    public interface IQuestion
    {
        int Id { get; }

        string Text { get; set; }

        int AnswerType { get; set; }
    }
}