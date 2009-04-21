using System.Linq;
using Domain;
using Domain.Repositories;
using System.Collections.Generic;

namespace Presentation
{
    public class AllTextAnswersViewModel : ViewModelBase
    {
        private readonly ITextAnswerRepository mTextAnswerRepository;

        public IEnumerable<TextAnswerViewModel> Answers { get; private set; }

        public AllTextAnswersViewModel(Form form, ITextAnswerRepository textAnswerRepository)
        {
            mTextAnswerRepository = textAnswerRepository;

            Answers = from answer in mTextAnswerRepository.CreateFor(form, Stage.Pre)
                select new TextAnswerViewModel(answer);
        }
    }
}