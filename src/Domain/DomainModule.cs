using System;
using Domain.Repositories;
using Ninject;
using Ninject.Modules;
namespace Domain
{
    public class DomainModule : INinjectModule
    {
        EvaluationSheetSelector evaluationSheetSelector = new EvaluationSheetSelector();

        public void OnLoad(IKernel kernel)
        {
            kernel.Bind<IFormFactory>().To<FormFactory>();
            kernel.Bind<IConfigurationProvider>().ToConstant(evaluationSheetSelector);
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