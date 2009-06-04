using System;
using System.Collections.Generic;
using System.Linq;
using Domain;
using Domain.Repositories;
using NHibernate;

namespace TheNewEngine.Datalayer.Repositories
{
    public abstract class AnswerRepositoryBase<T> : IAnswerRepository, IRepository<T>
    {
        private readonly ISession mSession;

        public AnswerRepositoryBase(ISession session)
        {
            mSession = session;
        }

        public IEnumerable<T> GetAll()
        {
            return Enumerable.Cast<T>(mSession.CreateCriteria(typeof(T)).List());
        }

        public void Insert(T item)
        {
            mSession.Save(item);
            mSession.Flush();
        }

        public abstract void CreateFor(Form form);

        protected IEnumerable<T> GetAnswersFor(AnswerType answerType,
            Func<Question, Stage, T> create)
        {
            return mSession.CreateQuery(
                "select q, s " +
                "from QuestionStage as s " +
                "inner join s.Question as q " +
                "where q.AnswerType = :answer_type")
                .SetParameter("answer_type", (int)answerType)
                .Enumerable().Cast<object>().Select(
                x =>
                {
                    var question = (Question)((object[])x)[0];
                    var stage = (QuestionStage)((object[])x)[1];

                    return create(question, stage.StageNumber);
                }).ToArray();
        }
    }
}