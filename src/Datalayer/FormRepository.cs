using System;
using System.Collections.Generic;
using Domain;
using System.Linq;
using Domain.Repositories;
using NHibernate;
using TheNewEngine.Datalayer.Entities;

namespace TheNewEngine.Datalayer
{
    public class FormRepository : IQuestionFormRepository
    {
        private readonly ISession mSession;

        public FormRepository(ISession session)
        {
            mSession = session;
        }

        public IEnumerable<IForm> GetAll()
        {
            return mSession.CreateCriteria(typeof(IForm)).List().Cast<IForm>();
        }

        public void Insert(IForm item)
        {
            mSession.Save(item);
            mSession.Flush();
        }
    }
}