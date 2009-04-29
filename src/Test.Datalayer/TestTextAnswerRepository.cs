using System.Linq;
using MbUnit.Framework;
using TheNewEngine.Datalayer.Repositories;
using Domain;

namespace TheNewEngine.Datalayer
{
    public class TestTextAnswerRepository : TestRepositoryBase
    {
        public TestTextAnswerRepository()
            : base("TestTextAnswerRepository.sdf")
        {
        }

        [Test]
        public void CreateFor()
        {
            var repository = new TextAnswerRepository(mSession);

            var textAnswers = repository.CreateFor(null);

            Assert.AreEqual(2, textAnswers.Count());
        }
    }
}