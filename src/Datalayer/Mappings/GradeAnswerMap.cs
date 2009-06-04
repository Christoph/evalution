using Domain;

namespace TheNewEngine.Datalayer.Mappings
{
    public class GradeAnswerMap : AnswerBaseMap<GradeAnswer>
    {
        public GradeAnswerMap()
        {
            Map(x => x.Answer).Nullable();
        }
    }
}