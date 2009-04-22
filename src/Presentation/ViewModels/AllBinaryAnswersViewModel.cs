using System.Collections.ObjectModel;
using Domain;
using Domain.Repositories;

namespace Presentation
{
    public class AllBinaryAnswersViewModel : ViewModelBase
    {
        private readonly CurrentFormHolder mCurrentFormHolder;

        private readonly IBinaryAnswerRepository mBinaryAnswerRepository;

        public ObservableCollection<BinaryAnswerViewModel> Answers { get; private set; }

        public AllBinaryAnswersViewModel(CurrentFormHolder currentFormHolder, IBinaryAnswerRepository binaryAnswerRepository)
        {
            mCurrentFormHolder = currentFormHolder;
            mBinaryAnswerRepository = binaryAnswerRepository;

            Answers = new ObservableCollection<BinaryAnswerViewModel>();

            mCurrentFormHolder.OnChanged += SetAnswers;

            SetAnswers(mCurrentFormHolder.Form);
        }

        private void SetAnswers(Form form)
        {
            Answers.Clear();
            foreach (var binaryAnswer in form.BinaryAnswers)
            {
                Answers.Add(new BinaryAnswerViewModel(binaryAnswer));
            }
        }
    }
}