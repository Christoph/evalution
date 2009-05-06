using System;
using System.IO;
using NHibernate;
using Ninject;
using Ninject.Modules;

namespace TheNewEngine.Datalayer
{
    public class DatalayerModule : INinjectModule
    {
        public void OnLoad(IKernel kernel)
        {
            string dbName = "Db.sdf";
            bool newDb = !File.Exists(dbName);
            if (newDb)
            {
                File.Copy(@"..\EmptyDb.sdf", dbName);
                DbAccess.GetSessionForEmptyDatabase(dbName);
            }
            var sessionFactory = DbAccess.CreateSessionFactory(dbName);
            ISession session = sessionFactory.OpenSession();

            if (newDb)
            {
                new DatabaseInitializer(session).InitDb();
            }

            kernel.Bind<ISession>().ToConstant(session);
        }

        public void OnUnload(IKernel kernel)
        {
            throw new NotImplementedException();
        }

        public IKernel Kernel
        {
            get { throw new NotImplementedException(); }
        }

        public string Name
        {
            get { return "Datalayer"; }
        }
    }
}