using FluentNHibernate.Mapping;
using Domain;

namespace TheNewEngine.Datalayer.Mappings
{
    public class TextAnswerMap : ClassMap<TextAnswer>
    {
        public TextAnswerMap()
        {
            Id(x => x.Id).Access.AsProperty().GeneratedBy.Increment();
            Map(x => x.Answer).WithLengthOf(512);
            HasOne(x => x.QuestionStage);
            References(x => x.Form);
            References(x => x.Question);
        }
    }
}