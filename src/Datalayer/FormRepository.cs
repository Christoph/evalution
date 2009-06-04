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

        private INHibernateQueryable<Form> mForms;

        public FormRepository(ISession session)
        {
            mSession = session;
            mForms = mSession.Linq<Form>();
        }

        public int GetNextId()
        {
            return mForms.Max(x => x.Id) + 1;
        }

        public void Insert(Form item)
        {
            mSession.Save(item);
            mSession.Flush();
        }

        public Form GetPreviousForm(int id)
        {
            if (!HasPrevious(id))
            {
                return null;
            }

            var previousId = id - 1;

            var previous = mForms
                .Where(x => x.Id == previousId)
                .SingleOrDefault();

            return previous;
        }

        public Form GetNextForm(int id)
        {
            if (!HasNext(id))
            {
                return null;
            }

            int nextId = id + 1;

            var next = mForms
                .Where(x => x.Id == nextId)
                .SingleOrDefault();

            return next;
        }

        public bool HasPrevious(int id)
        {
            return id > mForms.Min(x => x.Id);
        }

        public bool HasNext(int id)
        {
            return id < mForms.Max(x => x.Id);
        }

        public Form GetLast()
        {
            if (mForms.Count() > 0)
            {
                var lastId = mForms.Max(y => y.Id);
                return mForms.Where(x => x.Id == lastId).SingleOrDefault();
            }

            return null;
        }
    }
}