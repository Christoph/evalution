using System.Collections.Generic;
using System.Linq;
using Domain;
using Domain.Repositories;
using NHibernate;
using NHibernate.Linq;

namespace TheNewEngine.Datalayer.Repositories
{
    public class GradeAnswerRepository : IGradeAnswerRepository
    {
        private readonly ISession mSession;

        public GradeAnswerRepository(ISession session)
        {
            mSession = session;
        }

        public IEnumerable<GradeAnswer> GetAll()
        {
            return mSession.CreateCriteria(typeof (GradeAnswer)).List().Cast<GradeAnswer>();
        }

        public IEnumerable<GradeAnswer> CreateFor(Form form, Stage stage)
        {
            INHibernateQueryable<Question> questions = mSession.Linq<Question>();

            return (from question in questions
                    where question.AnswerType == (int)AnswerType.Grade
                    //where question.QuestionStages.Where(s => s.StageNumber == (int) stage).Count() == 1
                    select new GradeAnswer { Question = question })
                    .ToList().Cast<GradeAnswer>();
        }

        public void Insert(GradeAnswer item)
        {
            mSession.Save(item);
            mSession.Flush();
        }
    }
}