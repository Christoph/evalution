using System.Windows.Controls;
using Domain;
using Presentation.View;

namespace Presentation
{
    /// <summary>
    /// Interaction logic for AnswerControl.xaml
    /// </summary>
    public partial class AnswerControl : UserControl
    {
        private ICurrentFormHolder mCurrentFormHolder;

        public AnswerControl()
        {
            InitializeComponent();
        }

        public void CreateChildViews()
        {
            mCurrentFormHolder = DependencyResolver.Resolve<ICurrentFormHolder>();

            Pre.Children.Add(GetAllBinaryAnswersView("Vocabulary", Stage.Pre));

            During.Children.Add(GetAllBinaryAnswersView("Vocabulary", Stage.Post));
            During.Children.Add(GetAllGradeAnswersView("Grade the question", Stage.Post));

            /*Four steps sheet
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
            */
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
    }
}
