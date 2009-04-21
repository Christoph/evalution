using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Domain;
using Domain.Repositories;
using NHibernate;
using Presentation.View;
using TheNewEngine.Datalayer;
using TheNewEngine.Datalayer.Repositories;
using System.IO;

namespace Presentation
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
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

            //QuestionFormView
            var formView = new QuestionFormView();

            
            var form = new Form();
            var formViewModel = new QuestionFormViewModel(form, 
                new FormRepository(session));

            formView.DataContext = formViewModel;

            Stack.Children.Add(formView);

            //AllBinaryAnswersView
            var allBinaryAnswersView = new AllBinaryAnswersView();
            var allBinaryAnswersViewModel = new AllBinaryAnswersViewModel(form,
                new BinaryAnswerRepository(session));
            allBinaryAnswersView.DataContext = allBinaryAnswersViewModel;

            Stack.Children.Add(allBinaryAnswersView);

            //TextAnswersView

            var allTextAnswersView = new AllTextAnswersView();
            var allTextAnswersViewModel = new AllTextAnswersViewModel(form,
                new TextAnswerRepository(session));
            allTextAnswersView.DataContext = allTextAnswersViewModel;

            Stack.Children.Add(allTextAnswersView);

            //GradeAnswerView

            var allGradeAnswersView = new AllGradeAnswersView();
            var allGradeAnswersViewModel = new AllGradeAnswersViewModel(form,
                new GradeAnswerRepository(session));
            allGradeAnswersView.DataContext = allGradeAnswersViewModel;

            Stack.Children.Add(allGradeAnswersView);
        }

//
//        private class Repo : IBinaryAnswerRepository
//        {
//            public IEnumerable<IBinaryAnswer> GetAll()
//            {
//                return new[]
//                       {
//                           new BinaryAnswer {Question = new Question {Text = "First Q"}},
//                           new BinaryAnswer {Question = new Question {Text = "Question 2"}},
//                           new BinaryAnswer {Question = new Question {Text = "Question 3"}}
//                       };
//            }
//
//            public void Insert(IBinaryAnswer item)
//            {
//                throw new NotImplementedException();
//            }
//        }

//        private class TextRepo : ITextAnswerRepository
//        {
//            public IEnumerable<ITextAnswer> GetAll()
//            {
//                return new[]
//                       {
//                           new TextAnswer() {Question = new Question {Text = "1 Q"}},
//                           new TextAnswer() {Question = new Question {Text = "2 Q"}}
//                       };
//            }
//
//            public void Insert(ITextAnswer item)
//            {
//                throw new System.NotImplementedException();
//            }
//        }

//        private class GradeRepo : IGradeAnswerRepository
//        {
//            public IEnumerable<IGradeAnswer> GetAll()
//            {
//                return new[]
//                       {
//                           new GradeAnswer() {Question = new Question {Text = "Grade q 1"}},
//                           new GradeAnswer() {Question = new Question {Text = "Grade q 2"}}
//                       };
//            }
//
//            public void Insert(IGradeAnswer item)
//            {
//                throw new System.NotImplementedException();
//            }
//        }

//        private class TextAnswer : ITextAnswer
//        {
//            public IQuestion Question { get; set; }
//
//            public int Id { get; set; }
//
//            public string Answer { get; set; }
//        }
//
//        private class GradeAnswer : IGradeAnswer
//        {
//            public IQuestion Question { get; set; }
//
//            public int Id { get; set; }
//
//            public int? Answer { get; set; }
//        }
    }
}
