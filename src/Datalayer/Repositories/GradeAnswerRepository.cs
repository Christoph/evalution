using System.Collections.Generic;
using Domain;
using NHibernate;

namespace TheNewEngine.Datalayer.Repositories
{
    public class GradeAnswerRepository : AnswerRepositoryBase<GradeAnswer>
    {
        private readonly ISession mSession;

        public GradeAnswerRepository(ISession session)
            :base(session)
        {
            mSession = session;
        }

        public override IEnumerable<GradeAnswer> CreateFor(Form form)
        {
            var gradeAnswers = GetAnswersFor(AnswerType.Grade, (q, s) => new GradeAnswer
            {
                Question = q,
                QuestionStage = s,
                Form = form
            });

            foreach (var answer in gradeAnswers)
            {
                form.GradeAnswers.Add(answer);
            }

            return gradeAnswers;
        }
    }
}