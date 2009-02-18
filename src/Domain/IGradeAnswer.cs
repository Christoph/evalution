namespace Domain
{
    public interface IGradeAnswer : IAnswer
    {
        int Id { get; set; }

        int? Answer { get; set; }
    }
}