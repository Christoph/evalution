using System.Collections.ObjectModel;
using System.Linq;
using Domain;
using Domain.Repositories;
using System.Collections.Generic;

namespace Presentation
{
    public class AllGradeAnswersViewModel : ViewModelBase
    {
        private readonly CurrentFormHolder mCurrentFormHolder;

        private readonly IAnswerRepository<GradeAnswer> mGradeAnswerRepository;

        private readonly Stage mStage;

        public ObservableCollection<GradeAnswerViewModel> Answers { get; private set; }

        public AllGradeAnswersViewModel(CurrentFormHolder currentFormHolder,
            IAnswerRepository<GradeAnswer> gradeAnswerRepository, Stage stage)
        {
            mCurrentFormHolder = currentFormHolder;
            mGradeAnswerRepository = gradeAnswerRepository;
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