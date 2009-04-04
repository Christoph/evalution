using System;
using System.Collections.Generic;
using Domain;
using System.Linq;
using Domain.Repositories;

namespace TheNewEngine.Datalayer
{
    public class FormRepository : IQuestionFormRepository
    {
        public IEnumerable<IForm> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Insert(IForm item)
        {
            throw new NotImplementedException();
        }
    }
}