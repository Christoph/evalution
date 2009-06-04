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
        public void HasPrevious()
        {
            Form form1 = new Form { Name = "Form1" };
            Form form2 = new Form { Name = "Form2" };

            var repository = new FormRepository(mSession);

            repository.Insert(form1);
            repository.Insert(form2);

            Assert.IsTrue(repository.HasPrevious(form2.Id));
        }

        [Test]
        public void HasPrevious_should_return_false_if_it_is_the_first_form()
        {
            Form form1 = new Form { Name = "Form1" };
            Form form2 = new Form { Name = "Form2" };

            var repository = new FormRepository(mSession);

            repository.Insert(form1);
            repository.Insert(form2);

            Assert.IsFalse(repository.HasPrevious(form1.Id));
        }

        [Test]
        public void HasPrevious_should_return_false_if_no_form_exists_yet()
        {
            var repository = new FormRepository(mSession);

            Assert.IsFalse(repository.HasPrevious(1));
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
        public void HasNext()
        {
            Form form1 = new Form { Name = "Form1" };
            Form form2 = new Form { Name = "Form2" };

            var repository = new FormRepository(mSession);

            repository.Insert(form1);
            repository.Insert(form2);

            Assert.IsTrue(repository.HasNext(form1.Id));
        }

        [Test]
        public void HasNext_and_returns_false_if_none_exists()
        {
            Form form1 = new Form { Name = "Form1" };
            Form form2 = new Form { Name = "Form2" };

            var repository = new FormRepository(mSession);

            repository.Insert(form1);
            repository.Insert(form2);

            Assert.IsFalse(repository.HasNext(form2.Id));
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

        [Test]
        public void GetPreviousForm_returns_null_when_at_first_position()
        {
            Form form1 = new Form {Name = "Form1"};

            var repository = new FormRepository(mSession);

            repository.Insert(form1);

            var previous = repository.GetPreviousForm(form1.Id);

            Assert.IsNull(previous);
        }
    }
}