using System.Collections.Generic;
using Domain;
using Domain.Repositories;
using NHibernate;

namespace TheNewEngine.Datalayer.Repositories
{
    public class BinaryAnswerRepository : AnswerRepositoryBase<BinaryAnswer>
    {
        public BinaryAnswerRepository(ISession session)
            : base(session)
        {
        }
        
        public override void CreateFor(Form form)
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
        }
    }
}