namespace Domain
{
    public interface IBinaryAnswer : IAnswer
    {
        int Id { get; set; }

        bool? Answer { get; set; }
    }
}