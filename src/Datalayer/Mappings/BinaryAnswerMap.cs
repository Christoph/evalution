using FluentNHibernate.Mapping;
using TheNewEngine.Datalayer.Entities;

namespace TheNewEngine.Datalayer.Mappings
{
    public class BinaryAnswerMap : ClassMap<BinaryAnswer>
    {
        public BinaryAnswerMap()
        {
            Id(x => x.Id);
            Map(x => x.Answer).Nullable();
            References(x => x.FormRelation);
            References(x => x.QuestionRelation);
        }
    }
}