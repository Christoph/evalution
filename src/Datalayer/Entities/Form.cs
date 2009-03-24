using System.Collections.Generic;

namespace TheNewEngine.Datalayer.Entities
{
    public class Form
    {
        public virtual int Id { get; private set; }
        public virtual string Name { get; set; }
        public virtual string School { get; set; }
        public virtual string Email { get; set; }
        public virtual int Age { get; set; }
        public virtual bool Gender { get; set; }
        public virtual int Grade { get; set; }
        public virtual string Instrument { get; set; }
        public virtual IList<Question> Questions { get; set; }

        public Form()
        {
            Questions = new List<Question>();
        }
    }
}