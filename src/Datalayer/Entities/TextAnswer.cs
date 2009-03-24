namespace TheNewEngine.Datalayer.Entities
{
    public class TextAnswer
    {
        public virtual int Id { get; private set; }
        public virtual string Text { get; set; }
        public virtual Form Form { get; set; }
        public virtual Question Question { get; set; }
    }
}