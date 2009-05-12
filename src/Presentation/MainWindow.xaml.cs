using System.Windows;
using Domain;
using Domain.Repositories;
using NHibernate;
using Ninject;
using Presentation.View;
using TheNewEngine.Datalayer;
using TheNewEngine.Datalayer.Repositories;

namespace Presentation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IQuestionFormRepository mFormRepository;

        public MainWindow()
        {
            InitializeComponent();

            InitializeDependencies();

            var answerControl = new AnswerControl();

            //QuestionFormView
            var formView = new QuestionFormView();

            var currentFormHolder = DependencyResolver.Resolve<ICurrentFormHolder>();
            var formViewModel = new QuestionFormViewModel(currentFormHolder,
                mFormRepository);

            formView.DataContext = formViewModel;
            
            TopContent.Children.Add(formView);

            BottomContent.Children.Add(answerControl);
        }

        private void InitializeDependencies()
        {
            IKernel kernel = new StandardKernel(new DatalayerModule(), new DomainModule());

            DependencyResolver.InitializeWith(kernel);

            var session = DependencyResolver.Resolve<ISession>();

            var binaryAnswerRepository = new BinaryAnswerRepository(session);
            var songAnswerRepository = new SongAnswerRepository(session);
            var textAnswerRepository = new TextAnswerRepository(session);
            var gradeAnswerRepository = new GradeAnswerRepository(session);
            mFormRepository = new FormRepository(session);

            var formFactory = new FormFactory(mFormRepository,
                gradeAnswerRepository, textAnswerRepository, binaryAnswerRepository, songAnswerRepository);

            var currentFormHolder = new CurrentFormHolder(mFormRepository.GetLast(), formFactory);

            kernel.Bind<ICurrentFormHolder>().ToConstant(currentFormHolder);
        }
    }
}
