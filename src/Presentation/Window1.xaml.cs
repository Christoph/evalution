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

            var formView = new QuestionFormView();

            var form = new Form
            {
                Name = "Chri*"
            };

            var formViewModel = new QuestionFormViewModel(form, 
                new FormRepository(new Db("Db.sdf")));

            formView.DataContext = formViewModel;

            Grid.Children.Add(formView);

            var binaryQuestionView = new BinaryQuestionView();

            var question = new BinaryQuestion() {Question = "die Doppelhaushälfte"};

            var binaryQustionViewModel = new BinaryQuestionViewModel(question);

            binaryQuestionView.DataContext = binaryQustionViewModel;

//            Grid.Children.Add(binaryQuestionView);
        }
    }
}
