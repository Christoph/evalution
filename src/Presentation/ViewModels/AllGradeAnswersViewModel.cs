using System.Collections.ObjectModel;
using System.Linq;
using Domain;

namespace Presentation
{
    public class AllGradeAnswersViewModel : AllAnswersViewModelBase
    {
        public ObservableCollection<GradeAnswerViewModel> Answers { get; private set; }

        public AllGradeAnswersViewModel(ICurrentFormHolder currentFormHolder,
            Stage stage, string header) : base(currentFormHolder,stage,header)
        {
            Answers = new ObservableCollection<GradeAnswerViewModel>();

            SetAnswers(mCurrentFormHolder.Form);
        }

        protected override void SetAnswers(Form form)
        {
            Answers.Clear();
            foreach (var gradeAnswer in form.GradeAnswers.Where(x => x.BelongsTo(mStage)))
            {
                Answers.Add(new GradeAnswerViewModel(gradeAnswer));
            }
        }
    }
}