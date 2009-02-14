using System;
using Domain;
using FluentNHibernate.AutoMap;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Mapping;
using MbUnit.Framework;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace Test.Datalayer
{
    public static class DbTestHelper
    {
        private static Configuration _configuration;
        private static ISessionFactory _sessionFactory;
        private const string SQL_SCRIPT_PATH = "Sql.txt";
        private const string DB_FILE_PATH = @"F:\Projects\Evalution\db\db.sdf";

        public static  ISession GetSessionForEmptyDatabase()
        {
            if (_sessionFactory == null)
            {
                _sessionFactory = _CreateSessionFactoryAutoMapping();
                new SchemaExport(_configuration).SetOutputFile(SQL_SCRIPT_PATH).Execute(true, false, false, true);
            }

            new SchemaExport(_configuration).Create(false, true);
            return _sessionFactory.OpenSession();
        }

        public static ISession CreateNewSession()
        {
            return _sessionFactory.OpenSession();
        }

        public static void Compare(DateTime expected, DateTime actual)
        {
            Assert.AreApproximatelyEqual(0, (expected - actual).TotalSeconds, 1);
        }

        public static void Compare(DateTime? expected, DateTime? actual)
        {
            if (expected == null && actual == null)
                return;

            Compare(expected.Value, actual.Value);
        }

        private static ISessionFactory _CreateSessionFactoryAutoMapping()
        {
            return Fluently.Configure()
                .Database(MsSqlCeConfiguration.Standard.ShowSql().ConnectionString(
                    c => c.Is("Data Source=" + DB_FILE_PATH)))
                .Mappings(m => m.AutoMappings.Add(AutoPersistenceModel.MapEntitiesFromAssemblyOf<QuestionForm>()
                .WithConvention(c =>
                    {
                        c.GetPrimaryKeyName = x => "Id";
                        c.IdConvention = x => x.GeneratedBy.Increment();
                        c.AddTypeConvention(new EnumerationTypeConvention());
                    })
                ))
                .ExposeConfiguration(c => _configuration = c)
                .BuildSessionFactory();
        }

        public static void CompareCollection<T>(T[] expected, T[] actual, Action<T, T> compareAction)
        {
            if (expected == null && actual == null)
                return;

            Assert.AreEqual(expected.Length, actual.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                compareAction(expected[i], actual[i]);
            }
        }
    }
}