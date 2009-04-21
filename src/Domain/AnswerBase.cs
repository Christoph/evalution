namespace Domain
{
    public class AnswerBase
    {
        public virtual int Id { get; private set; }

        public virtual Form Form { get; set; }
        
        public virtual Question Question { get; set; }
    }
}