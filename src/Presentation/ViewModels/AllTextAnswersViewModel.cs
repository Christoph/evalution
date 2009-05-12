using System.Collections.ObjectModel;
using System.Linq;
using Domain;

namespace Presentation
{
    public class AllTextAnswersViewModel : AllAnswersViewModelBase
    {
        public ObservableCollection<TextAnswerViewModel> Answers { get; private set; }

        public AllTextAnswersViewModel(ICurrentFormHolder currentFormHolder,
            Stage stage, string header) : base(currentFormHolder,stage,header)
        {
            Answers = new ObservableCollection<TextAnswerViewModel>();

            SetAnswers(mCurrentFormHolder.Form);
        }

        protected override void SetAnswers(Form form)
        {
            Answers.Clear();
            foreach (var textAnswer in form.TextAnswers.Where(x => x.BelongsTo(mStage)))
            {
                Answers.Add(new TextAnswerViewModel(textAnswer));
            }
        }
    }
}