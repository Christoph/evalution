using MbUnit.Framework;
using System.IO;
namespace TheNewEngine.Datalayer
{
    [TestFixture]
    public class TestDbAccess
    {
        private const string Path = "foo.sdf";

        [SetUp]
        public void Setup()
        {
            File.Copy(@"..\EmptyDb.sdf", Path);
        }

        [TearDown]
        public void Teardown()
        {
            File.Delete(Path);
        }

        [Test]
        public void CreateSessionFactory()
        {
            var session = DbAccess.CreateSessionFactory(Path);
            Assert.IsNotNull(session);
            Assert.IsTrue(File.Exists(Path), "Database was not created.");
        }

        [Test]
        public void GetSessionFormEmptyDatabase()
        {
            var session = DbAccess.GetSessionForEmptyDatabase(Path);

            Assert.IsTrue(File.Exists(Path), "Database was not created.");
            Assert.IsNotNull(session);
        }
    }
}