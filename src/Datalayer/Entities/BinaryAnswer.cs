using Domain;
namespace TheNewEngine.Datalayer.Entities
{
    public class BinaryAnswer : AnswerBase, IBinaryAnswer
    {
        public virtual bool? Answer { get; set; }
    }
}