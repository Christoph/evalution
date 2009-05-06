using System.Collections.Generic;
using Domain;
using NHibernate;

namespace TheNewEngine.Datalayer.Repositories
{
    public class TextAnswerRepository : AnswerRepositoryBase<TextAnswer>
    {
        public TextAnswerRepository(ISession session)
            :base(session)
        {
        }

        public override IEnumerable<TextAnswer> CreateFor(Form form)
        {
            var textAnswers = GetAnswersFor(AnswerType.Text, (q, s) => new TextAnswer
            {
                Question = q,
                QuestionStage = s,
                Form = form
            });

            foreach (var answer in textAnswers)
            {
                form.TextAnswers.Add(answer);
            }

            return textAnswers;
        }
    }
}