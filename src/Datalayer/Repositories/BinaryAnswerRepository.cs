using System;
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

            return (from question in questions
                    where question.AnswerType == (int) AnswerType.Binary
                    //where question.QuestionStages.Where(s => s.StageNumber == (int) stage).Count() == 1
                    select new BinaryAnswer { QuestionRelation = question})
                    .ToList().Cast<IBinaryAnswer>();
        }

        public void Insert(IBinaryAnswer item)
        {
            mSession.Save(item);
            mSession.Flush();
        }
    }
}