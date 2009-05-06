using System.Linq;
using Domain;
using MbUnit.Framework;
using TheNewEngine.Datalayer.Repositories;

namespace TheNewEngine.Datalayer
{
    public class TestSongAnswerRepository : TestRepositoryBase
    {
        public TestSongAnswerRepository()
            :base("TestSongAnswerRepository.sdf")
        {
        }

        [Test]
        public void CreateFor()
        {
            var repository = new SongAnswerRepository(mSession);

            var form = new Form();
            repository.CreateFor(form);

            Assert.AreEqual(44, form.SongAnswers.Count);
        }
    }
}