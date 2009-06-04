namespace Domain
{
    public class QuestionStage
    {
        public virtual int Id { get; private set; }
        public virtual Stage StageNumber { get; set; }
        public virtual Question Question { get; set; }
    }
}