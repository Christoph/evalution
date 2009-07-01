using System.Linq;
using Domain.Repositories;
using MbUnit.Framework;
using NHibernate;
using TheNewEngine.Datalayer;
using TheNewEngine.Datalayer.Repositories;

namespace Domain
{
    public class TestFormFactory : TestRepositoryBase
    {
        public TestFormFactory()
            :base("TestFormFactory")
        {
        }

        [Test]
        public void Name()
        {
            var binaryAnswerRepository = new BinaryAnswerRepository(mSession);
            var songAnswerRepository = new SongAnswerRepository(mSession);
            var textAnswerRepository = new TextAnswerRepository(mSession);
            var gradeAnswerRepository = new GradeAnswerRepository(mSession);
            var formRepository = new FormRepository(mSession);

            var formFactory = new FormFactory(
                formRepository, gradeAnswerRepository, textAnswerRepository, 
                binaryAnswerRepository, songAnswerRepository);

            var form = formFactory.CreateNew();
            var binaryPreCount = form.BinaryAnswers.Where(x => x.BelongsTo(Stage.Pre)).Count();
            Assert.AreEqual(11, binaryPreCount);

            formRepository.Insert(form);
            binaryPreCount = form.BinaryAnswers.Where(x => x.BelongsTo(Stage.Pre)).Count();
            Assert.AreEqual(11, binaryPreCount);
            mSession.Close();

            var sessionFactory = DbAccess.CreateSessionFactory(mDbName);
            mSession = sessionFactory.OpenSession();

            var readForm = new FormRepository(mSession).GetLast();

            Assert.AreEqual(form.Id, readForm.Id);
            binaryPreCount = readForm.BinaryAnswers.Where(x => x.BelongsTo(Stage.Pre)).Count();
            Assert.AreEqual(11, binaryPreCount);
        }
    }
}