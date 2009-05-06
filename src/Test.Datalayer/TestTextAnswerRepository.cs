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
            repository.CreateFor(form);

            Assert.AreEqual(2, form.TextAnswers.Count);
        }
    }
}