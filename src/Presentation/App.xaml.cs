using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using Domain;
using Domain.Repositories;
using NHibernate;
using Ninject;
using TheNewEngine.Datalayer;
using TheNewEngine.Datalayer.Repositories;

namespace Presentation
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            InitializeDependencies();
        }

        private static void InitializeDependencies()
        {
            IKernel kernel = new StandardKernel(new DomainModule(), new DatalayerModule());
            
            DependencyResolver.InitializeWith(kernel);

            var session = DependencyResolver.Resolve<ISession>();

            var binaryAnswerRepository = new BinaryAnswerRepository(session);
            var songAnswerRepository = new SongAnswerRepository(session);
            var textAnswerRepository = new TextAnswerRepository(session);
            var gradeAnswerRepository = new GradeAnswerRepository(session);
            var formRepository = new FormRepository(session);
            kernel.Bind<IQuestionFormRepository>().ToConstant(formRepository);

            var formFactory = new FormFactory(formRepository, gradeAnswerRepository, textAnswerRepository, binaryAnswerRepository, songAnswerRepository);
            var currentFormHolder = new CurrentFormHolder(formRepository.GetLast(), formFactory);

            kernel.Bind<ICurrentFormHolder>().ToConstant(currentFormHolder);
        }
    }
}
