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

            var form = new Form();
            var textAnswers = repository.CreateFor(form);

            var expectedAnswerCount = 2;

            Assert.AreEqual(expectedAnswerCount, textAnswers.Count());
            Assert.AreEqual(expectedAnswerCount, form.TextAnswers.Count);
        }
    }
}