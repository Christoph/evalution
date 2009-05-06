using System.Collections.Generic;

namespace Domain
{
    public class Form
    {
        public virtual int Id { get; private set; }
        public virtual string Name { get; set; }
        public virtual string School { get; set; }
        public virtual string Email { get; set; }
        public virtual string Class { get; set; }
        public virtual int? Age { get; set; }
        public virtual bool? Gender { get; set; }
        public virtual int? Grade { get; set; }
        public virtual string Instrument { get; set; }

        public virtual IList<TextAnswer> TextAnswers { get; set; }
        public virtual IList<BinaryAnswer> BinaryAnswers { get; set; }
        public virtual IList<BinaryAnswer> SongAnswers { get; set; }
        public virtual IList<GradeAnswer> GradeAnswers { get; set; }

        internal Form()
        {
            TextAnswers = new List<TextAnswer>();
            BinaryAnswers = new List<BinaryAnswer>();
            GradeAnswers = new List<GradeAnswer>();
            SongAnswers = new List<BinaryAnswer>();
        }

        public virtual void AddTextAnswer(TextAnswer textAnswer)
        {
            textAnswer.Form = this;
            TextAnswers.Add(textAnswer);
        }
        public virtual void AddGradeAnswer(GradeAnswer gradeAnswer)
        {
            gradeAnswer.Form = this;
            GradeAnswers.Add(gradeAnswer);
        }
        public virtual void AddBinaryAnswer(BinaryAnswer binaryAnswer)
        {
            binaryAnswer.Form = this;
            BinaryAnswers.Add(binaryAnswer);
        }
        public virtual void AddSongAnswer(BinaryAnswer songAnswer)
        {
            songAnswer.Form = this;
            SongAnswers.Add(songAnswer);
        }
    }
}