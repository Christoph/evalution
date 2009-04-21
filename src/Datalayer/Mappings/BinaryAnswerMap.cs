using FluentNHibernate.Mapping;
using Domain;

namespace TheNewEngine.Datalayer.Mappings
{
    public class BinaryAnswerMap : ClassMap<BinaryAnswer>
    {
        public BinaryAnswerMap()
        {
            Id(x => x.Id);
            Map(x => x.Answer).Nullable();
            References(x => x.Form);
            References(x => x.Question);
        }
    }
}