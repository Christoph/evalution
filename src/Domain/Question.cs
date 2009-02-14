using System.Collections.Generic;

namespace Domain
{
    public class Question
    {
        public virtual int Id { get; set; }

        public virtual string Text { get; set; }

        public virtual AnswerType AnswerType { get; set; }

        public virtual IList<Stage> Stages { get; set; }
    }
}