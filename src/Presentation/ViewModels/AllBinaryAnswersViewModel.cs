using System.Collections.Generic;
using System.Linq;
using TheNewEngine.Datalayer;

namespace Presentation
{
    public class AllBinaryAnswersViewModel : ViewModelBase
    {
        private readonly IBinaryAnswerRepository mBinaryAnswerRepository;

        public IEnumerable<BinaryAnswerViewModel> Answers { get; private set; }

        public AllBinaryAnswersViewModel(IBinaryAnswerRepository binaryAnswerRepository)
        {
            mBinaryAnswerRepository = binaryAnswerRepository;
            
            Answers = from answer in mBinaryAnswerRepository.GetAll()
                select new BinaryAnswerViewModel(answer);
        }
    }
}