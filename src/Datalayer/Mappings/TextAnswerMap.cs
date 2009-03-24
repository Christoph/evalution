using FluentNHibernate.Mapping;

namespace TheNewEngine.Datalayer.Mappings
{
    public class TextAnswerMap : ClassMap<TextAnswer>
    {
        public TextAnswerMap()
        {
            Id(x => x.Id);
            Map(x => x.Text);
            References(x => x.Form);
            References(x => x.Question);
        }
    }
}