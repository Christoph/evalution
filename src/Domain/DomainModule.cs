using System;
using Ninject;
using Ninject.Modules;
namespace Domain
{
    public class DomainModule : INinjectModule
    {
        public void OnLoad(IKernel kernel)
        {
            kernel.Bind<IFormFactory>().To<FormFactory>();
        }

        public void OnUnload(IKernel kernel)
        {
            throw new NotImplementedException();
        }

        public IKernel Kernel
        {
            get { throw new NotImplementedException(); }
        }

        public string Name
        {
            get { return "Domain"; }
        }
    }
}