using System;
using System.Collections.Generic;
using Domain;
using NHibernate;

namespace TheNewEngine.Datalayer.Repositories
{
    public class SongAnswerRepository : AnswerRepositoryBase<BinaryAnswer>
    {
        public SongAnswerRepository(ISession session)
            : base(session)
        {
        }

        public override void CreateFor(Form form)
        {
            var binaryAnswers = GetAnswersFor(AnswerType.Song, (q, s) => new BinaryAnswer
            {
                Question = q,
                QuestionStage = s,
                Form = form
            });

            foreach (var answer in binaryAnswers)
            {
                form.SongAnswers.Add(answer);
            }
        }
    }
}