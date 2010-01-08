using System.Windows.Controls;
using Domain;
using Domain.Repositories;
using Presentation.View;

namespace Presentation
{
    /// <summary>
    /// Interaction logic for AnswerControl.xaml
    /// </summary>
    public partial class AnswerControl : UserControl
    {
        private ICurrentFormHolder mCurrentFormHolder;
        private IConfigurationProvider mConfigurationProvider;

        public AnswerControl()
        {
            InitializeComponent();
        }

        public void CreateChildViews()
        {
            mCurrentFormHolder = DependencyResolver.Resolve<ICurrentFormHolder>();
            mConfigurationProvider = DependencyResolver.Resolve<IConfigurationProvider>();
            
            switch (mConfigurationProvider.Configuration)
            {
                case Configurations.TwoStepsSheet:
                    InitialzeTwoStepsSheetWordSet2();
                    break;

                case Configurations.ThreeStepsSheet:
                    InitializeFourStepsSheetWordSet1();
                    break;

                case Configurations.TwoStepsSheetTwo:
                    InitialzeTwoStepsSheetWordSet3();
                    break;

                case Configurations.TwoStepsSheetThree:
                    InitialzeTwoStepsSheetWordSet4();
                    break;
            }

            mCurrentFormHolder.OnChanged += x => Stack.SelectedIndex = 0;
        }

        public void InitialzeTwoStepsSheetWordSet2()
        {
            ThirdTab.IsEnabled = false;
            ThirdTab.Opacity = 0;

            Pre.Children.Add(GetAllBinaryAnswersView("Vocabulary", Stage.PreTwo));

            During.Children.Add(GetAllBinaryAnswersView("Vocabulary", Stage.PostTwo));
            During.Children.Add(GetAllGradeAnswersView("Grade the question", Stage.Post));
            During.Children.Add(GetAllBinaryAnswersView("Questions", Stage.PreYesNo));
            During.Children.Add(GetAllTextAnswersView("Please fill in:", Stage.Pre));
        }

        public void InitialzeTwoStepsSheetWordSet3()
        {
            ThirdTab.IsEnabled = false;
            ThirdTab.Opacity = 0;

            Pre.Children.Add(GetAllBinaryAnswersView("Vocabulary", Stage.PreThree));

            During.Children.Add(GetAllBinaryAnswersView("Vocabulary", Stage.PostThree));
            During.Children.Add(GetAllGradeAnswersView("Grade the question", Stage.Post));
            During.Children.Add(GetAllBinaryAnswersView("Questions", Stage.PreYesNo));
            During.Children.Add(GetAllTextAnswersView("Please fill in:", Stage.Pre));
        }

        public void InitialzeTwoStepsSheetWordSet4()
        {
            ThirdTab.IsEnabled = false;
            ThirdTab.Opacity = 0;

            Pre.Children.Add(GetAllBinaryAnswersView("Vocabulary", Stage.PreFour));

            During.Children.Add(GetAllBinaryAnswersView("Vocabulary", Stage.PostFour));
            During.Children.Add(GetAllGradeAnswersView("Grade the question", Stage.Post));
            During.Children.Add(GetAllBinaryAnswersView("Questions", Stage.PreYesNo));
            During.Children.Add(GetAllTextAnswersView("Please fill in:", Stage.Pre));
        }
        
        public void InitializeFourStepsSheetWordSet1()
        {
            ThirdTab.IsEnabled = true;
            ThirdTab.Opacity = 1;
            
            Pre.Children.Add(GetAllBinaryAnswersView("Vocabulary", Stage.Pre));
            Pre.Children.Add(GetAllSongsAnswersView("Songs", Stage.PreSong));
            Pre.Children.Add(GetAllGradeAnswersView("Grade the questions", Stage.Pre));
            Pre.Children.Add(GetAllBinaryAnswersView("Questions",Stage.PreYesNo));
            Pre.Children.Add(GetAllTextAnswersView("Text", Stage.Pre));

            During.Children.Add(GetAllBinaryAnswersView("Vocabulary", Stage.During));
            During.Children.Add(GetAllSongsAnswersView("Songs", Stage.DuringSong));
            During.Children.Add(GetAllBinaryAnswersView("Vocabulary with help", Stage.DuringWithHelp));
            During.Children.Add(GetAllSongsAnswersView("Songs with help", Stage.DuringWithHelpSong));
            During.Children.Add(GetAllBinaryAnswersView("Questions", Stage.DuringYesNo));

            Past.Children.Add(GetAllBinaryAnswersView("Vocabulary", Stage.Post));
            Past.Children.Add(GetAllSongsAnswersView("Songs", Stage.PostSong));
        }
        

        private AllTextAnswersView GetAllTextAnswersView(string name, Stage stage)
        {
            var allTextAnswersView = new AllTextAnswersView();

            var allTextAnswersViewModel = new AllTextAnswersViewModel(
                mCurrentFormHolder, stage, name);
            allTextAnswersView.DataContext = allTextAnswersViewModel;

            return allTextAnswersView;
        }

        private AllGradeAnswersView GetAllGradeAnswersView(string name, Stage stage)
        {
            var allGradeAnswersView = new AllGradeAnswersView();

            var allGradeAnswersViewModel = new AllGradeAnswersViewModel(mCurrentFormHolder, stage, name);
            allGradeAnswersView.DataContext = allGradeAnswersViewModel;

            return allGradeAnswersView;
        }

        private AllBinaryAnswersView GetAllBinaryAnswersView(string name, Stage stage)
        {
            var allBinaryAnswersView = new AllBinaryAnswersView();

            var allBinaryAnswersViewModel = new AllBinaryAnswersViewModel(
                mCurrentFormHolder, stage, x => x.BinaryAnswers, name);
            allBinaryAnswersView.DataContext = allBinaryAnswersViewModel;
            return allBinaryAnswersView;
        }

        private AllBinaryAnswersView GetAllSongsAnswersView(string name, Stage stage)
        {
            var allBinaryAnswersView = new AllBinaryAnswersView();

            var allBinaryAnswersViewModel = new AllBinaryAnswersViewModel(
                mCurrentFormHolder, stage, x => x.SongAnswers, name);
            allBinaryAnswersView.DataContext = allBinaryAnswersViewModel;
            return allBinaryAnswersView;
        }

        private void Stack_PreviewMouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
        {
        	if (e.Delta < 0)
            {
               	ScrollViewer.LineDown();
            }
            else
            {
                ScrollViewer.LineUp();
            }
        }
        
        public void SetFirstTab()
        {
            FirstTab.IsSelected = true;
        }
    }
}
