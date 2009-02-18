namespace Domain
{
    public interface IQuestion
    {
        int Id { get; set; }

        string Text { get; set; }

        int AnswerType { get; set; }
    }
}