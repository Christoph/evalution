using System.Collections.Generic;
using System.Linq;
using Domain;
using Domain.Repositories;
using NHibernate;
using NHibernate.Linq;
using TheNewEngine.Datalayer.Entities;

namespace TheNewEngine.Datalayer.Repositories
{
    public class BinaryAnswerRepository : IBinaryAnswerRepository
    {
        private readonly ISession mSession;

        public BinaryAnswerRepository(ISession session)
        {
            mSession = session;
        }

        public IEnumerable<IBinaryAnswer> GetAll()
        {
            return mSession.CreateCriteria(typeof(IBinaryAnswer)).List().Cast<IBinaryAnswer>();
        }

        public IEnumerable<IBinaryAnswer> CreateFor(IForm form, Stage stage)
        {
            INHibernateQueryable<Question> questions = mSession.Linq<Question>();
            var questionStages = mSession.Linq<QuestionStage>();

            //var f = from questionStage in questionStages
            //    where questionStage.StageNumber == (int)stage
            //    let question = questionStage.Question
            //    where question.AnswerType == (int)AnswerType.Binary
            //    select new BinaryAnswer {QuestionRelation = question};

            //return f.ToList().Cast<IBinaryAnswer>();

            var filteredQuestionStages = from questionStage in questionStages
                where questionStage.StageNumber == (int)stage
                select questionStage.Id;

            var f = from question in questions
                where question.AnswerType == (int)AnswerType.Binary
                where filteredQuestionStages.Contains(question.Id)
                select new BinaryAnswer { QuestionRelation = question };

            return f.ToList().Cast<IBinaryAnswer>();
        }

        public void Insert(IBinaryAnswer item)
        {
            mSession.Save(item);
            mSession.Flush();
        }
    }
}