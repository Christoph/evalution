using System.Collections.Generic;
using Domain;

namespace TheNewEngine.Datalayer.Entities
{
    public class Form : IForm
    {
        public virtual int Id { get; private set; }
        public virtual string Name { get; set; }
        public virtual string School { get; set; }
        public virtual string Email { get; set; }
        public virtual int? Age { get; set; }
        public virtual bool? Gender { get; set; }
        public virtual int? Grade { get; set; }
        public virtual string Instrument { get; set; }

        public virtual IList<TextAnswer> TextAnswers { get; set; }
        public virtual IList<BinaryAnswer> BinaryAnswers { get; set; }
        public virtual IList<GradeAnswer> GradeAnswers { get; set; }

        public Form()
        {
            TextAnswers = new List<TextAnswer>();
            BinaryAnswers = new List<BinaryAnswer>();
            GradeAnswers = new List<GradeAnswer>();
        }

        public virtual void AddTextAnswer(TextAnswer textAnswer)
        {
            textAnswer.FormRelation = this;
            TextAnswers.Add(textAnswer);
        }
        public virtual void AddGradeAnswer(GradeAnswer gradeAnswer)
        {
            gradeAnswer.FormRelation = this;
            GradeAnswers.Add(gradeAnswer);
        }
        public virtual void AddBinaryAnswer(BinaryAnswer binaryAnswer)
        {
            binaryAnswer.FormRelation = this;
            BinaryAnswers.Add(binaryAnswer);
        }
    }
}