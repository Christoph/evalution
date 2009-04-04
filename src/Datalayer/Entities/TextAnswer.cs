using Domain;
namespace TheNewEngine.Datalayer.Entities
{
    public class TextAnswer : AnswerBase, ITextAnswer
    {
        public virtual string Answer { get; set; }
    }
}