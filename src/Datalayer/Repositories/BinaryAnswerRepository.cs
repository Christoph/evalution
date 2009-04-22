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
            var temp = mSession.CreateQuery(
                "select q " +
                "from QuestionStage as s " +
                "inner join s.Question as q " +
                "where q.AnswerType = :answer_type and s.StageNumber = :stage_number ")
                .SetParameter("answer_type", (int)AnswerType.Binary)
                .SetParameter("stage_number", (int)stage)
                .List<Question>();

            return temp.Select(x => new BinaryAnswer { Question = x });
        }

        public void Insert(BinaryAnswer item)
        {
            mSession.Save(item);
            mSession.Flush();
        }
    }
}