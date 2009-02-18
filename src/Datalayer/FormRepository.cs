using System.Collections.Generic;
using Domain;
using System.Linq;

namespace TheNewEngine.Datalayer
{
    public class FormRepository : IQuestionFormRepository
    {
        private readonly Db mDb;

        public FormRepository(Db db)
        {
            mDb = db;
        }

        public IEnumerable<IQuestionForm> GetAll()
        {
            return mDb.Form.Cast<IQuestionForm>();
        }

        public void Insert(IQuestionForm form)
        {
            mDb.Form.InsertOnSubmit((Form)form);
            mDb.SubmitChanges();
        }
    }
}