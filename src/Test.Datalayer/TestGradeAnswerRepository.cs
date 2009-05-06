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
            var gradeAnswers = repository.CreateFor(form);

            var expectedAnswerCount = 7;

            Assert.AreEqual(expectedAnswerCount, gradeAnswers.Count());
            Assert.AreEqual(expectedAnswerCount, form.GradeAnswers.Count);
        }
    }
}