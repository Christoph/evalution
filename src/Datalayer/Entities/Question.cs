using System.Collections.Generic;
using Domain;

namespace TheNewEngine.Datalayer.Entities
{
    public class Question : IQuestion
    {
        public virtual int Id { get; private set; }
        public virtual string Text { get; set; }
        public virtual int AnswerType{ get; set; }

        public virtual IList<TextAnswer> TextAnswers { get; set; }
        public virtual IList<BinaryAnswer> BinaryAnswers { get; set; }
        public virtual IList<GradeAnswer> GradeAnswers { get; set; }
        public virtual IList<QuestionStage> QuestionStages { get; set; }

        public Question()
        {
            TextAnswers = new List<TextAnswer>();
            BinaryAnswers = new List<BinaryAnswer>();
            GradeAnswers = new List<GradeAnswer>();
            QuestionStages = new List<QuestionStage>();
        }

        public virtual void AddTextAnswer(TextAnswer textAnswer)
        {
            textAnswer.QuestionRelation = this;
            TextAnswers.Add(textAnswer);
        }
        public virtual void AddGradeAnswer(GradeAnswer gradeAnswer)
        {
            gradeAnswer.QuestionRelation = this;
            GradeAnswers.Add(gradeAnswer);
        }
        public virtual void AddBinaryAnswer(BinaryAnswer binaryAnswer)
        {
            binaryAnswer.QuestionRelation = this;
            BinaryAnswers.Add(binaryAnswer);
        }
        public virtual void AddQuestionStage(QuestionStage questionStage)
        {
            questionStage.Question = this;
            QuestionStages.Add(questionStage);
        }
    }
}