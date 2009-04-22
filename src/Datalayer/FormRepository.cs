using System;
using System.Collections.Generic;
using Domain;
using System.Linq;
using Domain.Repositories;
using NHibernate;
using NHibernate.Linq;

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

        public Form GetPreviousForm(int id)
        {
            int previousId = id - 1;

            var previous = mSession.Linq<Form>()
                .Where(x => x.Id == previousId)
                .SingleOrDefault();

            return previous;
        }

        public Form GetNextForm(int id)
        {
            var forms = mSession.Linq<Form>();

            int maxId = forms.Max(x => x.Id);

            if (id >= maxId)
            {
                return null;
            }

            int nextId = id + 1;

            var next = forms
                .Where(x => x.Id == nextId)
                .SingleOrDefault();

            return next;
        }
    }
}