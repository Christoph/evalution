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
        public void CreateFor()
        {
            var repository = new BinaryAnswerRepository(mSession);

            var form = new Form();
            var binaryAnswers = repository.CreateFor(form);

            var expectedAnswerCount = 51;

            Assert.AreEqual(expectedAnswerCount, binaryAnswers.Count());
            Assert.AreEqual(expectedAnswerCount, form.BinaryAnswers.Count);
        }

        [Test]
        public void BelongsTo()
        {
            var repository = new BinaryAnswerRepository(mSession);

            var form = new Form();
            var binaryAnswers = repository.CreateFor(form);

            Assert.AreEqual(14, binaryAnswers.Where(b => b.BelongsTo(Stage.Pre)).Count());
        }
    }
}