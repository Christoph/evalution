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
using Presentation.View;
using TheNewEngine.Datalayer;

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


            //QuestionFormView
            var formView = new QuestionFormView();

            var form = new Form
            {
                Name = "Chri*"
            };

            var formViewModel = new QuestionFormViewModel(form, 
                new FormRepository(new Db("Db.sdf")));

            formView.DataContext = formViewModel;

            Stack.Children.Add(formView);

            //AllBinaryAnswersView
            var allBinaryAnswersView = new AllBinaryAnswersView();
            var allBinaryAnswersViewModel = new AllBinaryAnswersViewModel(
                new Repo());
            allBinaryAnswersView.DataContext = allBinaryAnswersViewModel;

            Stack.Children.Add(allBinaryAnswersView);

            //TextAnswersView

            var allTextAnswersView = new AllTextAnswersView();
            var allTextAnswersViewModel = new AllTextAnswersViewModel(
                new TextRepo());
            allTextAnswersView.DataContext = allTextAnswersViewModel;

            Stack.Children.Add(allTextAnswersView);

            //GradeAnswerView

            var allGradeAnswersView = new AllGradeAnswersView();
            var allGradeAnswersViewModel = new AllGradeAnswersViewModel(
                new GradeRepo());
            allGradeAnswersView.DataContext = allGradeAnswersViewModel;

            Stack.Children.Add(allGradeAnswersView);
        }

        private class BinaryAnswer : IBinaryAnswer
        {
            public IQuestion Question { get; set; }

            public int Id { get; set; }

            public bool? Answer { get; set; }
        }

        private class Question : IQuestion
        {
            public int Id { get; set; }

            public string Text { get; set; }

            public int AnswerType { get; set; }
        }

        private class Repo : IBinaryAnswerRepository
        {
            public IEnumerable<IBinaryAnswer> GetAll()
            {
                return new[]
                       {
                           new BinaryAnswer {Question = new Question {Text = "First Q"}},
                           new BinaryAnswer {Question = new Question {Text = "Question 2"}},
                           new BinaryAnswer {Question = new Question {Text = "Question 3"}}
                       };
            }

            public void Insert(IBinaryAnswer item)
            {
                throw new NotImplementedException();
            }
        }

        private class TextRepo : ITextAnswerRepository
        {
            public IEnumerable<ITextAnswer> GetAll()
            {
                return new[]
                       {
                           new TextAnswer() {Question = new Question {Text = "1 Q"}},
                           new TextAnswer() {Question = new Question {Text = "2 Q"}}
                       };
            }

            public void Insert(ITextAnswer item)
            {
                throw new System.NotImplementedException();
            }
        }

        private class GradeRepo : IGradeAnswerRepository
        {
            public IEnumerable<IGradeAnswer> GetAll()
            {
                return new[]
                       {
                           new GradeAnswer() {Question = new Question {Text = "Grade q 1"}},
                           new GradeAnswer() {Question = new Question {Text = "Grade q 2"}}
                       };
            }

            public void Insert(IGradeAnswer item)
            {
                throw new System.NotImplementedException();
            }
        }

        private class TextAnswer : ITextAnswer
        {
            public IQuestion Question { get; set; }

            public int Id { get; set; }

            public string Answer { get; set; }
        }

        private class GradeAnswer : IGradeAnswer
        {
            public IQuestion Question { get; set; }

            public int Id { get; set; }

            public int? Answer { get; set; }
        }
    }
}
