using FluentNHibernate.Mapping;
using Domain;

namespace TheNewEngine.Datalayer.Mappings
{
    public class FormMap : ClassMap<Form>
    {
        public FormMap()
        {
            Id(x => x.Id).Access.AsProperty().GeneratedBy.Increment();
            Map(x => x.Age).Nullable();
            Map(x => x.Email).Nullable().WithLengthOf(512);
            Map(x => x.Gender).Nullable();
            Map(x => x.Class).Nullable().WithLengthOf(512);
            Map(x => x.Grade).Nullable();
            Map(x => x.Instrument).Nullable().WithLengthOf(512);
            Map(x => x.Name).Nullable().WithLengthOf(512);
            Map(x => x.School).Nullable().WithLengthOf(512);

            HasMany(x => x.TextAnswers)
                .Cascade.All();
            HasMany(x => x.BinaryAnswers)
                .Cascade.All();
            HasMany(x => x.SongAnswers)
                .Cascade.All();
            HasMany(x => x.GradeAnswers)
                .Cascade.All();
        }
    }
}