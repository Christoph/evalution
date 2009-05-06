using System.Windows;
using Domain;
using NHibernate;
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
            string dbName = "Db.sdf";
            bool newDb = !File.Exists(dbName);
            if (newDb)
            {
                File.Copy(@"..\EmptyDb.sdf", dbName);
                DbAccess.GetSessionForEmptyDatabase(dbName);
            }
            var sessionFactory = DbAccess.CreateSessionFactory(dbName);
            ISession session = sessionFactory.OpenSession();

            if (newDb)
            {
                new DatabaseInitializer(session).InitDb();
            }

            var binaryAnswerRepository = new BinaryAnswerRepository(session);
            var songAnswerRepository = new SongAnswerRepository(session);

            //QuestionFormView
            var formView = new QuestionFormView();

            var currentFormHolder = new CurrentFormHolder(new FormFactory(binaryAnswerRepository, songAnswerRepository));
            var formViewModel = new QuestionFormViewModel(currentFormHolder, 
                new FormRepository(session));

            formView.DataContext = formViewModel;

            Stack.Children.Add(formView);

            //AllBinaryAnswersView
            var allBinaryAnswersView = new AllBinaryAnswersView();
            
            var allBinaryAnswersViewModel = new AllBinaryAnswersViewModel(currentFormHolder,
                binaryAnswerRepository, Stage.Pre, x => x.BinaryAnswers);
            allBinaryAnswersView.DataContext = allBinaryAnswersViewModel;

            Stack.Children.Add(allBinaryAnswersView);

            var allSongAnswersView = new AllBinaryAnswersView();

            var allSongAnswersViewModel = new AllBinaryAnswersViewModel(
                currentFormHolder, songAnswerRepository, Stage.Pre, x => x.SongAnswers);
            allSongAnswersView.DataContext = allSongAnswersViewModel;

            Stack.Children.Add(allSongAnswersView);

            //TextAnswersView

//            var allTextAnswersView = new AllTextAnswersView();
//            var allTextAnswersViewModel = new AllTextAnswersViewModel(form,
//                new TextAnswerRepository(session));
//            allTextAnswersView.DataContext = allTextAnswersViewModel;

//            Stack.Children.Add(allTextAnswersView);

            //GradeAnswerView

//            var allGradeAnswersView = new AllGradeAnswersView();
//            var allGradeAnswersViewModel = new AllGradeAnswersViewModel(form,
//                new GradeAnswerRepository(session));
//            allGradeAnswersView.DataContext = allGradeAnswersViewModel;

//            Stack.Children.Add(allGradeAnswersView);
        }
    }
}
