using System.Linq;
using Domain.Repositories;
using System.Collections.Generic;

namespace Presentation
{
    public class AllTextAnswersViewModel : ViewModelBase
    {
        private readonly ITextAnswerRepository mTextAnswerRepository;

        public IEnumerable<TextAnswerViewModel> Answers { get; private set; }

        public AllTextAnswersViewModel(ITextAnswerRepository textAnswerRepository)
        {
            mTextAnswerRepository = textAnswerRepository;

            Answers = from answer in mTextAnswerRepository.GetAll()
                select new TextAnswerViewModel(answer);
        }
    }
}