using FluentNHibernate.Mapping;
using TheNewEngine.Datalayer.Entities;

namespace TheNewEngine.Datalayer.Mappings
{
    public class FormMap : ClassMap<Form>
    {
        public FormMap()
        {
            Id(x => x.Id);
            Map(x => x.Age);
            Map(x => x.Email).Nullable();
            Map(x => x.Gender);
            Map(x => x.Grade);
            Map(x => x.Instrument);
            Map(x => x.Name);
            Map(x => x.School);

            HasMany(x => x.TextAnswers)
                .Cascade.All();
            HasMany(x => x.BinaryAnswers)
                .Cascade.All();
            HasMany(x => x.GradeAnswers)
                .Cascade.All();
        }
    }
}