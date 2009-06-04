using Domain;
using FluentNHibernate.Mapping;

namespace TheNewEngine.Datalayer.Mappings
{
    public class AnswerBaseMap<T> : ClassMap<T>
        where T:AnswerBase
    {
        public AnswerBaseMap()
        {
            Id(x => x.Id).Access.AsProperty().GeneratedBy.Increment();
            Map(x => x.QuestionStage).CustomTypeIs(typeof(Stage));
            References(x => x.Form);
            References(x => x.Question);
        }
    }
}