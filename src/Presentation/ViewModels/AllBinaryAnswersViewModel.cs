using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Domain;
using Domain.Repositories;

namespace Presentation
{
    public class AllBinaryAnswersViewModel : AllAnswersViewModelBase
    {
        private readonly Func<Form, IList<BinaryAnswer>> mGetAnswers;

        public ObservableCollection<BinaryAnswerViewModel> Answers { get; private set; }

        public AllBinaryAnswersViewModel(ICurrentFormHolder currentFormHolder,
            Stage stage, Func<Form, IList<BinaryAnswer>> getAnswers,
            string header) : base(currentFormHolder,stage,header)
        {
            mGetAnswers = getAnswers;
            
            Answers = new ObservableCollection<BinaryAnswerViewModel>();

            SetAnswers(mCurrentFormHolder.Form);
        }

        protected override void SetAnswers(Form form)
        {
            Answers.Clear();
            foreach (var binaryAnswer in mGetAnswers(form).Where(x => x.BelongsTo(mStage)))
            {
                Answers.Add(new BinaryAnswerViewModel(binaryAnswer));
            }
        }
    }
}