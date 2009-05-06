using System.Collections.ObjectModel;
using System.Linq;
using Domain;

namespace Presentation
{
    public class AllGradeAnswersViewModel : ViewModelBase
    {
        private readonly CurrentFormHolder mCurrentFormHolder;

        private readonly Stage mStage;

        public ObservableCollection<GradeAnswerViewModel> Answers { get; private set; }

        public AllGradeAnswersViewModel(CurrentFormHolder currentFormHolder,
            Stage stage)
        {
            mCurrentFormHolder = currentFormHolder;
            mStage = stage;

            Answers = new ObservableCollection<GradeAnswerViewModel>();

            mCurrentFormHolder.OnChanged += SetAnswers;

            SetAnswers(mCurrentFormHolder.Form);
        }

        private void SetAnswers(Form form)
        {
            Answers.Clear();
            foreach (var gradeAnswer in form.GradeAnswers.Where(x => x.BelongsTo(mStage)))
            {
                Answers.Add(new GradeAnswerViewModel(gradeAnswer));
            }
        }
    }
}