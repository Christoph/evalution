using FluentNHibernate.Mapping;
using TheNewEngine.Datalayer.Entities;

namespace TheNewEngine.Datalayer.Mappings
{
    public class QuestionMap : ClassMap<Question>
    {
        public QuestionMap()
        {
            Id(x => x.Id);
            Map(x => x.Text);
            Map(x => x.AnswerType);

            HasMany(x => x.TextAnswers);
            HasMany(x => x.BinaryAnswers);
            HasMany(x => x.GradeAnswers);
            HasMany(x => x.QuestionStages);
        }
    }
}