using MbUnit.Framework;
using NHibernate;

namespace Test.Datalayer
{
    public class TestBase
    {
        protected ISession _session;

        [SetUp]
        public void Setup()
        {
            _session = DbTestHelper.GetSessionForEmptyDatabase();
        }

        protected void SaveAndFlush(params object[] newObjects)
        {
            foreach (var obj in newObjects)
                _session.SaveOrUpdate(obj);
            _session.Flush();
            SetupNewSession();
        }

        protected void SaveAndFlush(object newObject)
        {
            _session.SaveOrUpdate(newObject);
            _session.Flush();
            SetupNewSession();
        }

        protected void SetupNewSession()
        {
            _session = DbTestHelper.CreateNewSession();
        }
    }
}