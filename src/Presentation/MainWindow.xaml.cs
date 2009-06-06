using System.Windows;
using Domain;

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

            var formViewModel = DependencyResolver.Resolve<QuestionFormViewModel>();
            FormView.DataContext = formViewModel;

            var buttonsViewModel = DependencyResolver.Resolve <ButtonsViewModel>();
            ButtonsView.DataContext = buttonsViewModel;
        }
    }
}
