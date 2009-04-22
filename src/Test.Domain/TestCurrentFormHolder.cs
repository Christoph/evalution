using MbUnit.Framework;
using Moq;

namespace Domain
{
    public class TestCurrentFormHolder
    {
        private CurrentFormHolder mHolder;

        [SetUp]
        public void Setup()
        {
            var factory = new Mock<IFormFactory>();
            factory.Setup(x => x.CreateNew()).Returns(() => new Form());

            mHolder = new CurrentFormHolder(factory.Object);
        }

        [Test]
        public void Constructor_Creates_New_Form()
        {
            Assert.IsNotNull(mHolder.Form);
        }

        [Test]
        public void Form_setter_creates_a_new_form_if_the_given_value_is_null()
        {
            var oldForm = mHolder.Form;

            mHolder.Form = null;

            Assert.IsNotNull(mHolder.Form);
            Assert.AreNotSame(mHolder.Form, oldForm);
        }
    }
}