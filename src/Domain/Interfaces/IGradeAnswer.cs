namespace Domain
{
    public interface IGradeAnswer : IAnswer
    {
        int Id { get; }

        int? Answer { get; set; }
    }
}