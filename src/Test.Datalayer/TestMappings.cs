using Domain;
using MbUnit.Framework;
using System.Linq;

namespace Test.Datalayer
{
    public class TestMappings : TestBase
    {
        [Test]
        public void Ig()
        {
            var form = new QuestionForm();
            form.Age = 5;
            form.Email = "email";
            SaveAndFlush(form);
            SetupNewSession();

            var context = new DbContext(_session);
            Assert.AreEqual(1, context.QuestionForms.Count());

        }
    }
}