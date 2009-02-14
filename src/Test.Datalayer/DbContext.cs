using System.Linq;
using Domain;
using NHibernate;
using NHibernate.Linq;

namespace Test.Datalayer
{
    public class DbContext : NHibernateContext
    {
        public DbContext(ISession session)
            : base(session)
        {
        }

        public IOrderedQueryable<QuestionForm> QuestionForms
        {
            get { return Session.Linq<QuestionForm>(); }
        }
        
    }
}