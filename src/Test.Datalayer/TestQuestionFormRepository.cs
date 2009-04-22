using Domain;
using MbUnit.Framework;

namespace TheNewEngine.Datalayer
{
    public class TestQuestionFormRepository : TestRepositoryBase
    {
        public TestQuestionFormRepository()
            : base("TestQuestionFormRepository.sdf")
        {
            
        }

        [Test]
        public void GetPrevious()
        {
            Form form1 = new Form{ Name = "Form1"};
            Form form2 = new Form{ Name = "Form2"};

            var repository = new FormRepository(mSession);

            repository.Insert(form1);
            repository.Insert(form2);

            var previous = repository.GetPreviousForm(form2.Id);

            Assert.AreEqual(form1.Name, previous.Name);
        }

        [Test]
        public void GetNext()
        {
            Form form1 = new Form { Name = "Form1" };
            Form form2 = new Form { Name = "Form2" };

            var repository = new FormRepository(mSession);

            repository.Insert(form1);
            repository.Insert(form2);

            var next = repository.GetNextForm(form1.Id);

            Assert.AreEqual(form2.Name, next.Name);
        }

        [Test]
        public void GetNextForm_returns_null_when_at_last_index()
        {
            Form form1 = new Form { Name = "Form1" };

            var repository = new FormRepository(mSession);

            repository.Insert(form1);

            var next = repository.GetNextForm(form1.Id);

            Assert.IsNull(next);
        }
    }
}