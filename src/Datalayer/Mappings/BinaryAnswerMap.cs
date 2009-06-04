using Domain;

namespace TheNewEngine.Datalayer.Mappings
{
    public class BinaryAnswerMap : AnswerBaseMap<BinaryAnswer>
    {
        public BinaryAnswerMap()
        {
            Map(x => x.Answer).Nullable(); 
        }
    }
}