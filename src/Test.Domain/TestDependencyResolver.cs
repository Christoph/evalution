using MbUnit.Framework;
using Ninject;

namespace Domain
{
    public class TestDependencyResolver
    {
        public interface IFoo
        {
            
        }

        public class FooImp : IFoo
        {
            
        }

        public interface ITest
        {
            IFoo Interface
            {
                get;
            }

        }

        public class TestImp : ITest
        {
            public TestImp(IFoo inter)
            {
                Interface = inter;
            }

            public IFoo Interface { get; private set; }
        }

        [Test]
        public void Resolve()
        {
            IKernel kernel = new StandardKernel();
            kernel.Bind<IFoo>().To<FooImp>();

            DependencyResolver.InitializeWith(kernel);

            var foo = DependencyResolver.Resolve<IFoo>();

            Assert.IsNotNull(foo);
        }

        [Test]
        public void Resolve_with_Constructor_Resolution()
        {
            IKernel kernel = new StandardKernel();
            kernel.Bind<IFoo>().To<FooImp>();
            kernel.Bind<ITest>().To<TestImp>();

            DependencyResolver.InitializeWith(kernel);

            var test = DependencyResolver.Resolve<ITest>();

            Assert.IsNotNull(test);
            Assert.IsNotNull(test.Interface);
        }
    }
}