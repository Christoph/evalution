using System.Collections.Generic;
using Domain;
using System.Linq;
using Domain.Repositories;
using NHibernate;

namespace TheNewEngine.Datalayer
{
    public class FormRepository : IQuestionFormRepository
    {
        private readonly ISession mSession;

        public FormRepository(ISession session)
        {
            mSession = session;
        }

        public IEnumerable<Form> GetAll()
        {
            return mSession.CreateCriteria(typeof(Form)).List().Cast<Form>();
        }

        public void Insert(Form item)
        {
            mSession.Save(item);
            mSession.Flush();
        }
    }
}