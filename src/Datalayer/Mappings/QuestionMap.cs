using FluentNHibernate.Mapping;

namespace TheNewEngine.Datalayer.Mappings
{
    public class QuestionMap : ClassMap<Question>
    {
        public QuestionMap()
        {
            Id(x => x.Id);
            Map(x => x.Text);
            Map(x => x.AnswerType);

            HasMany(x => x.TextAnswer);
            HasMany(x => x.BinaryAnswer);
            HasMany(x => x.GradeAnswer);
            HasMany(x => x.QuestionStage);
        }
    }
}