using FluentNHibernate.Mapping;

namespace TheNewEngine.Datalayer.Mappings
{
    public class GradeAnswerMap : ClassMap<GradeAnswer>
    {
        public GradeAnswerMap()
        {
            Id(x => x.Id);
            Map(x => x.Grade);
            References(x => x.Form);
            References(x => x.Question);
        }
    }
}