using FluentNHibernate.Mapping;
using TheNewEngine.Datalayer.Entities;

namespace TheNewEngine.Datalayer.Mappings
{
    public class GradeAnswerMap : ClassMap<GradeAnswer>
    {
        public GradeAnswerMap()
        {
            Id(x => x.Id);
            Map(x => x.Answer);
            References(x => x.FormRelation);
            References(x => x.QuestionRelation);
        }
    }
}