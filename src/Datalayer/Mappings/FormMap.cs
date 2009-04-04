using FluentNHibernate.Mapping;

namespace TheNewEngine.Datalayer.Mappings
{
    public class FormMap : ClassMap<Form>
    {
        public FormMap()
        {
            Id(x => x.Id);
            Map(x => x.Age);
            Map(x => x.Email);
            Map(x => x.Gender);
            Map(x => x.Grade);
            Map(x => x.Instrument);
            Map(x => x.Name);
            Map(x => x.School);

            HasMany(x => x.TextAnswer)
                .Cascade.All();
            HasMany(x => x.BinaryAnswer)
                .Cascade.All();
            HasMany(x => x.GradeAnswer)
                .Cascade.All();
        }
    }
}