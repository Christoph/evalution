using System.Collections.ObjectModel;
using System.Linq;
using Domain;
using Domain.Repositories;
using System.Collections.Generic;

namespace Presentation
{
    public class AllTextAnswersViewModel : ViewModelBase
    {
        private readonly CurrentFormHolder mCurrentFormHolder;

        private readonly Stage mStage;

        private readonly IAnswerRepository<TextAnswer> mTextAnswerRepository;

        public ObservableCollection<TextAnswerViewModel> Answers { get; private set; }

        public AllTextAnswersViewModel(CurrentFormHolder currentFormHolder,
            IAnswerRepository<TextAnswer> textAnswerRepository, Stage stage)
        {
            mCurrentFormHolder = currentFormHolder;
            mStage = stage;
            mTextAnswerRepository = textAnswerRepository;

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