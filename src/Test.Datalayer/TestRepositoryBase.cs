using System;
using System.IO;
using MbUnit.Framework;
using NHibernate;
using Gallio.Framework;

namespace TheNewEngine.Datalayer
{
    public class TestRepositoryBase
    {
        private string mDbName;

        protected ISession mSession;

        public TestRepositoryBase(string dbName)
        {
            mDbName = dbName;
        }

        [SetUp]
        public void Setup()
        {
            File.Copy(@"..\EmptyDb.sdf", mDbName);
            TestLog.WriteLine(Environment.CurrentDirectory);
            DbAccess.GetSessionForEmptyDatabase(mDbName);

            var sessionFactory = DbAccess.CreateSessionFactory(mDbName);
            mSession = sessionFactory.OpenSession();

            new DatabaseInitializer(mSession).InitDb();
        }

        [TearDown]
        public void Teardown()
        {
            if (File.Exists(mDbName))
            {
                File.Delete(mDbName);
            }
        }
    }
}