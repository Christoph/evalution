using System.Collections.ObjectModel;
using System.Linq;
using Domain;
using Domain.Repositories;

namespace Presentation
{
    public class AllBinaryAnswersViewModel : ViewModelBase
    {
        private readonly CurrentFormHolder mCurrentFormHolder;

        private readonly IBinaryAnswerRepository mBinaryAnswerRepository;

        private readonly Stage mStage;

        public ObservableCollection<BinaryAnswerViewModel> Answers { get; private set; }

        public AllBinaryAnswersViewModel(CurrentFormHolder currentFormHolder,
            IBinaryAnswerRepository binaryAnswerRepository, Stage stage)
        {
            mCurrentFormHolder = currentFormHolder;
            mBinaryAnswerRepository = binaryAnswerRepository;
            mStage = stage;

            Answers = new ObservableCollection<BinaryAnswerViewModel>();

            mCurrentFormHolder.OnChanged += SetAnswers;

            SetAnswers(mCurrentFormHolder.Form);
        }

        private void SetAnswers(Form form)
        {
            Answers.Clear();
            foreach (var binaryAnswer in form.BinaryAnswers.Where(x => x.BelongsTo(mStage)))
            {
                Answers.Add(new BinaryAnswerViewModel(binaryAnswer));
            }
        }
    }
}