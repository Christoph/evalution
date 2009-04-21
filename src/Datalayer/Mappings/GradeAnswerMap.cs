using FluentNHibernate.Mapping;
using Domain;

namespace TheNewEngine.Datalayer.Mappings
{
    public class GradeAnswerMap : ClassMap<GradeAnswer>
    {
        public GradeAnswerMap()
        {
            Id(x => x.Id);
            Map(x => x.Answer).Nullable();
            References(x => x.Form);
            References(x => x.Question);
        }
    }
}