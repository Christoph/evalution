namespace Domain
{
    public class QuestionStage
    {
        public virtual int Id { get; private set; }
        public virtual int StageNumber { get; set; }
        public virtual Question Question { get; set; }
    }
}