namespace TheNewEngine.Datalayer.Entities
{
    public class GradeAnswer
    {
        public virtual int Id { get; private set; }
        public virtual int Grade { get; set; }
        public virtual Form Form { get; set; }
        public virtual Question Question { get; set; }
    }
}