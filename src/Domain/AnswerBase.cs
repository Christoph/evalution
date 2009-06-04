namespace Domain
{
    public class AnswerBase
    {
        public virtual int Id { get; private set; }

        public virtual Form Form { get; set; }
        
        public virtual Question Question { get; set; }

        public virtual Stage QuestionStage { get; set; }

        public virtual bool BelongsTo(Stage stage)
        {
            return QuestionStage == stage;
        }
    }
}