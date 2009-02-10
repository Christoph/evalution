using System.Collections.Generic;

namespace TheNewEngine.Datalayer
{
    public class FormRepository
    {
        private readonly Db mDb;

        public FormRepository(Db db)
        {
            mDb = db;
        }

        public IEnumerable<Form> GetAllForms()
        {
            return mDb.Form;
        }

        public void Insert(Form form)
        {
            mDb.Form.InsertOnSubmit(form);
            mDb.SubmitChanges();
        }
    }
}