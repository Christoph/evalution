using Domain;

namespace TheNewEngine.Datalayer.Mappings
{
    public class TextAnswerMap : AnswerBaseMap<TextAnswer>
    {
        public TextAnswerMap()
        {
            Map(x => x.Answer).WithLengthOf(512);
        }
    }
}