namespace TheNewEngine.Datalayer.Entities
{
    public class BinaryAnswer
    {
        public virtual int Id { get; private set; }
        public virtual bool Answer { get; set; }
        public virtual Form Form { get; set; }
        public virtual Question Question { get; set; }
    }
}