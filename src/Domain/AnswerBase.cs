namespace Domain
{
    public class AnswerBase
    {
        public virtual int Id { get; set; }
        public virtual Question Question { get; set; }
    }  
}