using FluentNHibernate.Mapping;
using TheNewEngine.Datalayer.Entities;

namespace TheNewEngine.Datalayer.Mappings
{
    public class QuestionStageMap : ClassMap<QuestionStage>
    {
        public QuestionStageMap()
        {
            Id(x => x.Id);
            Map(x => x.StageNumber);
            References(x => x.Question);
        }
    }
}