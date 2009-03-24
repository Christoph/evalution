using System.Collections;
using System.Collections.Generic;

namespace TheNewEngine.Datalayer.Entities
{
    public class Question
    {
        public virtual int Id { get; private set; }
        public virtual string Text { get; set; }
        public virtual int AnswerType{ get; set; }

        public virtual IList<Form> Forms { get; set; }
        public virtual IList<QuestionStage> QuestionStages { get; set; }

        public Question()
        {
            Forms = new List<Form>();
            QuestionStages = new List<QuestionStage>();
        }

        public virtual void AddQuestionStage(QuestionStage questionStage)
        {
            questionStage.Question = this;
            QuestionStages.Add(questionStage);
        }
    }
}