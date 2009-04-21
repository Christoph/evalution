using FluentNHibernate.Mapping;
using Domain;

namespace TheNewEngine.Datalayer.Mappings
{
    public class TextAnswerMap : ClassMap<TextAnswer>
    {
        public TextAnswerMap()
        {
            Id(x => x.Id);
            Map(x => x.Answer).WithLengthOf(512);
            References(x => x.Form);
            References(x => x.Question);
        }
    }
}