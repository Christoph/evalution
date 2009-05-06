using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Domain;
using Domain.Repositories;

namespace Presentation
{
    public class AllBinaryAnswersViewModel : ViewModelBase
    {
        private readonly ICurrentFormHolder mCurrentFormHolder;

        private readonly Stage mStage;

        private readonly Func<Form, IList<BinaryAnswer>> mGetAnswers;

        public ObservableCollection<BinaryAnswerViewModel> Answers { get; private set; }

        public AllBinaryAnswersViewModel(ICurrentFormHolder currentFormHolder,
            Stage stage, Func<Form, IList<BinaryAnswer>> getAnswers)
        {
            mCurrentFormHolder = currentFormHolder;
            mStage = stage;
            mGetAnswers = getAnswers;

            Answers = new ObservableCollection<BinaryAnswerViewModel>();

            mCurrentFormHolder.OnChanged += SetAnswers;

            SetAnswers(mCurrentFormHolder.Form);
        }

        private void SetAnswers(Form form)
        {
            Answers.Clear();
            foreach (var binaryAnswer in mGetAnswers(form).Where(x => x.BelongsTo(mStage)))
            {
                Answers.Add(new BinaryAnswerViewModel(binaryAnswer));
            }
        }
    }
}