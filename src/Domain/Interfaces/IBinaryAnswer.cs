namespace Domain
{
    public interface IBinaryAnswer : IAnswer
    {
        int Id { get;}

        bool? Answer { get; set; }
    }
}