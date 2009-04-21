using Domain;

namespace TheNewEngine.Datalayer.Entities
{
    public class AnswerBase
    {
        public virtual int Id { get; private set; }

        public virtual IForm Form { get { return FormRelation; } }
        public virtual Form FormRelation { get; set; }
        
        public virtual IQuestion Question { get { return QuestionRelation; } }
        public virtual Question QuestionRelation { get; set; }
    }
}