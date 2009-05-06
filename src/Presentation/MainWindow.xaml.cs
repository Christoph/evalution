using System.Windows;
using Domain;
using NHibernate;
using Ninject;
using Presentation.View;
using TheNewEngine.Datalayer;
using TheNewEngine.Datalayer.Repositories;
using System.IO;

namespace Presentation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            InitializeDependencies();

            ISession session = DependencyResolver.Resolve<ISession>();

            //QuestionFormView
            var formView = new QuestionFormView();

            var currentFormHolder = DependencyResolver.Resolve<ICurrentFormHolder>();
            var formViewModel = new QuestionFormViewModel(currentFormHolder, 
                new FormRepository(session));

            formView.DataContext = formViewModel;

            Stack.Children.Add(formView);

            //AllBinaryAnswersView
            var allBinaryAnswersView = new AllBinaryAnswersView();
            
            var allBinaryAnswersViewModel = new AllBinaryAnswersViewModel(currentFormHolder,
               Stage.Pre, x => x.BinaryAnswers);
            allBinaryAnswersView.DataContext = allBinaryAnswersViewModel;

            Stack.Children.Add(allBinaryAnswersView);

            var allSongAnswersView = new AllBinaryAnswersView();

            var allSongAnswersViewModel = new AllBinaryAnswersViewModel(
                currentFormHolder, Stage.Pre, x => x.SongAnswers);
            allSongAnswersView.DataContext = allSongAnswersViewModel;

            Stack.Children.Add(allSongAnswersView);

//            GradeAnswerView

            var allGradeAnswersView = new AllGradeAnswersView();

            var allGradeAnswersViewModel = new AllGradeAnswersViewModel(currentFormHolder,
                 Stage.Pre);
            allGradeAnswersView.DataContext = allGradeAnswersViewModel;

            Stack.Children.Add(allGradeAnswersView);
            
//            TextAnswersView

            var allTextAnswersView = new AllTextAnswersView();

            var allTextAnswersViewModel = new AllTextAnswersViewModel(currentFormHolder,
                 Stage.Pre);
            allTextAnswersView.DataContext = allTextAnswersViewModel;

            Stack.Children.Add(allTextAnswersView);
        }

        private void InitializeDependencies()
        {
            IKernel kernel = new StandardKernel(new DatalayerModule(), new DomainModule());

            DependencyResolver.InitializeWith(kernel);

            ISession session = DependencyResolver.Resolve<ISession>();

            var binaryAnswerRepository = new BinaryAnswerRepository(session);
            var songAnswerRepository = new SongAnswerRepository(session);
            var textAnswerRepository = new TextAnswerRepository(session);
            var gradeAnswerRepository = new GradeAnswerRepository(session);

            var formFactory = new FormFactory(
                gradeAnswerRepository, textAnswerRepository, binaryAnswerRepository, songAnswerRepository);

            var currentFormHolder = new CurrentFormHolder(formFactory);

            kernel.Bind<ICurrentFormHolder>().ToConstant(currentFormHolder);
        }
    }
}
