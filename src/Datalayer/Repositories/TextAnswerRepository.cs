using System.Collections.Generic;
using System.Linq;
using Domain;
using Domain.Repositories;
using NHibernate;
using NHibernate.Linq;
using TheNewEngine.Datalayer.Entities;

namespace TheNewEngine.Datalayer.Repositories
{
    public class TextAnswerRepository : ITextAnswerRepository
    {
        private readonly ISession mSession;

        public TextAnswerRepository(ISession session)
        {
            mSession = session;
        }

        public IEnumerable<ITextAnswer> GetAll()
        {
            return mSession.CreateCriteria(typeof (ITextAnswer)).List().Cast<ITextAnswer>();
        }

        public IEnumerable<ITextAnswer> CreateFor(IForm form, Stage stage)
        {
            INHibernateQueryable<Question> questions = mSession.Linq<Question>();

            var allTextQuestions = (from question in questions
                where question.AnswerType == (int)AnswerType.Text
                //where question.QuestionStages.Where(s => s.StageNumber == (int) stage).Count() == 1
                select question).ToList();

            return (from question in allTextQuestions
            where question.QuestionStages.Where(q => q.StageNumber == (int)stage).Count() >= 0
            select new TextAnswer {QuestionRelation = question}).Cast<ITextAnswer>();
        }

        public void Insert(ITextAnswer item)
        {
            mSession.Save(item);
            mSession.Flush();
        }
    }
}