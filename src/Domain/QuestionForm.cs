namespace Domain
{
    public class QuestionForm
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual string School { get; set; }

        public virtual string Email { get; set; }

        public virtual int Age { get; set; }

        public virtual bool GenderIsMale { get; set; }

        public virtual int Grade { get; set; }

        public virtual string Instrument { get; set; }
    }
}