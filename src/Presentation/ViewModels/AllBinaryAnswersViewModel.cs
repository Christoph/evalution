using System.Collections.Generic;
using System.Linq;
using Domain;
using Domain.Repositories;

namespace Presentation
{
    public class AllBinaryAnswersViewModel : ViewModelBase
    {
        private readonly IBinaryAnswerRepository mBinaryAnswerRepository;

        public IEnumerable<BinaryAnswerViewModel> Answers { get; private set; }

        public AllBinaryAnswersViewModel(Form form, IBinaryAnswerRepository binaryAnswerRepository)
        {
            mBinaryAnswerRepository = binaryAnswerRepository;
            
            Answers = from answer in mBinaryAnswerRepository.CreateFor(form, Stage.Pre)
                select new BinaryAnswerViewModel(answer);
        }
    }
}