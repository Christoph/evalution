using System.Collections.Generic;
using System.Linq;
using Domain;
using Domain.Repositories;
using NHibernate;

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

        public IEnumerable<BinaryAnswer> CreateFor(Form form)
        {
            var temp = mSession.CreateQuery(
                "select q, s " +
                "from QuestionStage as s " +
                "inner join s.Question as q " +
                "where (q.AnswerType = :answer_type1 or q.AnswerType = :answer_type2)")
                .SetParameter("answer_type1", (int)AnswerType.Binary)
                .SetParameter("answer_type2", (int)(AnswerType.Binary | AnswerType.Song));

            var binaryAnswers = temp.Enumerable().Cast<object>().Select(x => 
                new BinaryAnswer
                {
                    Question = (Question)((object[])x)[0],
                    QuestionStage = (QuestionStage)((object[])x)[1],
                    Form = form
                }).ToArray();

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