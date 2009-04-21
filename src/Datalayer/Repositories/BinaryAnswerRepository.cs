using System.Collections.Generic;
using System.Linq;
using Domain;
using Domain.Repositories;
using NHibernate;
using NHibernate.Linq;

namespace TheNewEngine.Datalayer.Repositories
{
    public class BinaryAnswerRepository : IBinaryAnswerRepository
    {
        private readonly ISession mSession;

        public BinaryAnswerRepository(ISession session)
        {
            mSession = session;
        }

        public IEnumerable<BinaryAnswer> GetAll()
        {
            return mSession.CreateCriteria(typeof(BinaryAnswer)).List().Cast<BinaryAnswer>();
        }

        public IEnumerable<BinaryAnswer> CreateFor(Form form, Stage stage)
        {
            INHibernateQueryable<Question> questions = mSession.Linq<Question>();
            var questionStages = mSession.Linq<QuestionStage>();

            //var f = from questionStage in questionStages
            //    where questionStage.StageNumber == (int)stage
            //    let question = questionStage.Question
            //    where question.AnswerType == (int)AnswerType.Binary
            //    select new BinaryAnswer {QuestionRelation = question};

            //return f.ToList().Cast<IBinaryAnswer>();

            var filteredQuestionStages = (from questionStage in questionStages
                                          where questionStage.StageNumber == (int)stage
                                          select questionStage.Id).ToArray();

            var binaryQuestions = questions
                .Where(q => q.AnswerType == (int)AnswerType.Binary)
                .ToArray();

            return binaryQuestions
                .Where(q => filteredQuestionStages.Contains(q.Id))
                .Select(q => new BinaryAnswer {Question = q});
        }

        public void Insert(BinaryAnswer item)
        {
            mSession.Save(item);
            mSession.Flush();
        }
    }
}