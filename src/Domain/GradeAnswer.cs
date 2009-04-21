using Domain;
namespace TheNewEngine.Datalayer.Entities
{
    public class GradeAnswer : AnswerBase, IGradeAnswer
    {
        public virtual int? Answer { get; set; }
    }
}