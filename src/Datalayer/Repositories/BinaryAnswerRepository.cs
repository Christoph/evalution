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
                "where (q.AnswerType = :answer_type1 or q.AnswerType = :answer_type2) and s.StageNumber = :stage_number ")
                .SetParameter("answer_type1", (int)AnswerType.Binary)
                .SetParameter("answer_type2", (int)(AnswerType.Binary | AnswerType.Song))
                .SetParameter("stage_number", (int)stage)
                .List<Question>();

            var binaryAnswers = temp.Select(x => new BinaryAnswer { Question = x, Form = form });

            foreach (var answer in binaryAnswers)
            {
                form.BinaryAnswers.Add(answer);
            }
            
            return binaryAnswers;
        }

        public void Insert(BinaryAnswer item)
        {
            mSession.Save(item);
            mSession.Flush();
        }
    }
}