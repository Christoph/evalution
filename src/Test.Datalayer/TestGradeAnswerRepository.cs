using System.Linq;
using MbUnit.Framework;
using TheNewEngine.Datalayer.Repositories;
using Domain;

namespace TheNewEngine.Datalayer
{
    public class TestGradeAnswerRepository : TestRepositoryBase
    {
        public TestGradeAnswerRepository()
            : base("TestGradeAnswerRepository.sdf")
        {
        }

        [Test]
        public void CreateFor()
        {
            var repository = new GradeAnswerRepository(mSession);

            var form = new Form();
            repository.CreateFor(form);

            Assert.AreEqual(7, form.GradeAnswers.Count);
        }
    }
}