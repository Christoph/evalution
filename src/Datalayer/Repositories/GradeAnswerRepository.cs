using System.Collections.Generic;
using System.Linq;
using Domain;
using Domain.Repositories;
using NHibernate;
using NHibernate.Linq;
using TheNewEngine.Datalayer.Entities;

namespace TheNewEngine.Datalayer.Repositories
{
    public class GradeAnswerRepository : IGradeAnswerRepository
    {
        private readonly ISession mSession;

        public GradeAnswerRepository(ISession session)
        {
            mSession = session;
        }

        public IEnumerable<IGradeAnswer> GetAll()
        {
            return mSession.CreateCriteria(typeof (IGradeAnswer)).List().Cast<IGradeAnswer>();
        }

        public IEnumerable<IGradeAnswer> CreateFor(IForm form, Stage stage)
        {
            INHibernateQueryable<Question> questions = mSession.Linq<Question>();

            return (from question in questions
                    where question.AnswerType == (int)AnswerType.Grade
                    //where question.QuestionStages.Where(s => s.StageNumber == (int) stage).Count() == 1
                    select new GradeAnswer { QuestionRelation = question })
                    .ToList().Cast<IGradeAnswer>();
        }

        public void Insert(IGradeAnswer item)
        {
            mSession.Save(item);
            mSession.Flush();
        }
    }
}