using FluentNHibernate.Mapping;
using Domain;

namespace TheNewEngine.Datalayer.Mappings
{
    public class QuestionStageMap : ClassMap<QuestionStage>
    {
        public QuestionStageMap()
        {
            Id(x => x.Id).Access.AsProperty().GeneratedBy.Increment();
            Map(x => x.StageNumber);
            References(x => x.Question);
        }
    }
}