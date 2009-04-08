using FluentNHibernate.Mapping;
using TheNewEngine.Datalayer.Entities;

namespace TheNewEngine.Datalayer.Mappings
{
    public class TextAnswerMap : ClassMap<TextAnswer>
    {
        public TextAnswerMap()
        {
            Id(x => x.Id);
            Map(x => x.Answer).WithLengthOf(512);
            References(x => x.FormRelation);
            References(x => x.QuestionRelation);
        }
    }
}