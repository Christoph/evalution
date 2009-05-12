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
        public AnswerControl()
        {
            InitializeComponent();
            var currentFormHolder = DependencyResolver.Resolve<ICurrentFormHolder>();

            // AllBinaryAnswersView
            var allBinaryAnswersView = new AllBinaryAnswersView();

            var allBinaryAnswersViewModel = new AllBinaryAnswersViewModel(
                currentFormHolder, Stage.Pre, x => x.BinaryAnswers, "Vocabulary");
            allBinaryAnswersView.DataContext = allBinaryAnswersViewModel;

            Stack.Children.Add(allBinaryAnswersView);

            // AllSongsAnswerView
            var allSongAnswersView = new AllBinaryAnswersView();

            var allSongAnswersViewModel = new AllBinaryAnswersViewModel(
                currentFormHolder, Stage.Pre, x => x.SongAnswers, "Songs");
            allSongAnswersView.DataContext = allSongAnswersViewModel;

            Stack.Children.Add(allSongAnswersView);

            // GradeAnswerView

            var allGradeAnswersView = new AllGradeAnswersView();

            var allGradeAnswersViewModel = new AllGradeAnswersViewModel(currentFormHolder, Stage.Pre, "Grades");
            allGradeAnswersView.DataContext = allGradeAnswersViewModel;

            Stack.Children.Add(allGradeAnswersView);

            // Yes_No
            var allYesNoAnswersView = new AllBinaryAnswersView();

            var allYesNoAnswersViewModel = new AllBinaryAnswersViewModel(
                currentFormHolder, Stage.PreYesNo, x => x.BinaryAnswers, "YesNo");
            allYesNoAnswersView.DataContext = allYesNoAnswersViewModel;

            Stack.Children.Add(allYesNoAnswersView);

            // TextAnswersView

            var allTextAnswersView = new AllTextAnswersView();

            var allTextAnswersViewModel = new AllTextAnswersViewModel(currentFormHolder, Stage.Pre, "Text");
            allTextAnswersView.DataContext = allTextAnswersViewModel;

            Stack.Children.Add(allTextAnswersView);
        }
    }
}
