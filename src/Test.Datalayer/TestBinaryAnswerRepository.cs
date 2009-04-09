using System.Linq;
using Domain;
using MbUnit.Framework;
using TheNewEngine.Datalayer.Repositories;

namespace TheNewEngine.Datalayer
{
    public class TestBinaryAnswerRepository : TestRepositoryBase
    {
        public TestBinaryAnswerRepository()
            :base("TestBinaryAnswerRepository.sdf")
        {
        }

        [Test]
        [Row(Stage.Pre, 29)]
        [Row(Stage.Post, 22)]
        public void CreateFor(Stage stage, int expectedAnswerCount)
        {
            var repository = new BinaryAnswerRepository(mSession);

            var textAnswers = repository.CreateFor(null, stage);

            Assert.AreEqual(expectedAnswerCount, textAnswers.Count());
        }
    }
}