using System;
using System.Collections.Generic;
using System.Linq;
using Domain;
using Domain.Repositories;
using NHibernate;

namespace TheNewEngine.Datalayer.Repositories
{
    public class BinaryAnswerRepository : AnswerRepositoryBase<BinaryAnswer>, IBinaryAnswerRepository
    {
        public BinaryAnswerRepository(ISession session)
            : base(session)
        {
        }
        
        public IEnumerable<BinaryAnswer> CreateFor(Form form)
        {
            var binaryAnswers = GetAnswersFor(AnswerType.Binary, (q, s) => new BinaryAnswer
            {
                Question = q,
                QuestionStage = s,
                Form = form
            });

            foreach (var answer in binaryAnswers)
            {
                form.BinaryAnswers.Add(answer);
            }
            
            return binaryAnswers;
        }
    }
}