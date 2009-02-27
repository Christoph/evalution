using MbUnit.Framework;
namespace TheNewEngine.Datalayer
{
    [TestFixture]
    public class TestDbAccess
    {
        [Test]
        public void CreateSessionFactory()
        {
            var session = DbAccess.CreateSessionFactory();
            Assert.IsNotNull(session);
        }
    }
}