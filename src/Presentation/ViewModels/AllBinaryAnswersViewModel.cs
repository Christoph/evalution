using System.Collections.Generic;
using System.Linq;
using Domain;
using Domain.Repositories;

namespace Presentation
{
    public class AllBinaryAnswersViewModel : ViewModelBase
    {
        private readonly CurrentFormHolder mCurrentFormHolder;

        private readonly IBinaryAnswerRepository mBinaryAnswerRepository;

        public IEnumerable<BinaryAnswerViewModel> Answers { get; private set; }

        public AllBinaryAnswersViewModel(CurrentFormHolder currentFormHolder, IBinaryAnswerRepository binaryAnswerRepository)
        {
            mCurrentFormHolder = currentFormHolder;
            mBinaryAnswerRepository = binaryAnswerRepository;

            SetAnswers();
        }

        private void SetAnswers()
        {
            Answers = from answer in mCurrentFormHolder.Form.BinaryAnswers
                      select new BinaryAnswerViewModel(answer);
        }
    }
}