using System;
using System.Windows;
using Domain;

namespace Presentation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ButtonsViewModel mButtonsViewModel;

        public MainWindow()
        {
            InitializeComponent();

            var formViewModel = DependencyResolver.Resolve<QuestionFormViewModel>();
            FormView.DataContext = formViewModel;

            mButtonsViewModel = DependencyResolver.Resolve <ButtonsViewModel>();
            ButtonsView.DataContext = mButtonsViewModel;

            AnswerView.CreateChildViews();

            Closing += MainWindow_Closing;
        }

        void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            mButtonsViewModel.Save();
        } 
    }
}
