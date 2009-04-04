using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace TheNewEngine.Datalayer
{
    public static class DbAccess
    {
        private const string SQL_SCRIPT_PATH = "Script.Sql";
        private const string DATABASE_PATH = "Db.sdf";

        private static ISessionFactory _sessionFactory;
        private static Configuration _configuration;

        public static ISessionFactory CreateSessionFactory(string dbPath)
        {
            return Fluently.Configure()
                .Database(MsSqlCeConfiguration.Standard.ShowSql().ConnectionString(
                    c => c.Is(@"data source=" + dbPath)))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<FormRepository>())
                .ExposeConfiguration(c => _configuration = c)
                .BuildSessionFactory();
        }

        public static ISession GetSessionForEmptyDatabase()
        {
            return GetSessionForEmptyDatabase(DATABASE_PATH);
        }

        public static ISession GetSessionForEmptyDatabase(string dbPath)
        {
            if (_sessionFactory == null)
            {
                _sessionFactory = CreateSessionFactory(dbPath);
                new SchemaExport(_configuration)
                    .SetOutputFile(SQL_SCRIPT_PATH)
                    .Execute(true, false, false, true);
            }

            new SchemaExport(_configuration).Create(false, true);
            return _sessionFactory.OpenSession();
        }

        public static ISession CreateNewSession()
        {
            return _sessionFactory.OpenSession();
        }
    }
}