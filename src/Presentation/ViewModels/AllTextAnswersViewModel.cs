using System.Collections.ObjectModel;
using System.Linq;
using Domain;

namespace Presentation
{
    public class AllTextAnswersViewModel : ViewModelBase
    {
        private readonly CurrentFormHolder mCurrentFormHolder;

        private readonly Stage mStage;

        public ObservableCollection<TextAnswerViewModel> Answers { get; private set; }

        public AllTextAnswersViewModel(CurrentFormHolder currentFormHolder, Stage stage)
        {
            mCurrentFormHolder = currentFormHolder;
            mStage = stage;

            Answers = new ObservableCollection<TextAnswerViewModel>();

            mCurrentFormHolder.OnChanged += SetAnswers;

            SetAnswers(mCurrentFormHolder.Form);
        }

        private void SetAnswers(Form form)
        {
            Answers.Clear();
            foreach (var textAnswer in form.TextAnswers.Where(x => x.BelongsTo(mStage)))
            {
                Answers.Add(new TextAnswerViewModel(textAnswer));
            }
        }
    }
}