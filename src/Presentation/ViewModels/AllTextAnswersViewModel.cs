using System.Linq;
using Domain;
using Domain.Repositories;
using System.Collections.Generic;

namespace Presentation
{
    public class AllTextAnswersViewModel : ViewModelBase
    {
        private readonly IAnswerRepository<TextAnswer> mTextAnswerRepository;

        public IEnumerable<TextAnswerViewModel> Answers { get; private set; }

        public AllTextAnswersViewModel(Form form, IAnswerRepository<TextAnswer> textAnswerRepository)
        {
            mTextAnswerRepository = textAnswerRepository;

            Answers = from answer in mTextAnswerRepository.CreateFor(form)
                select new TextAnswerViewModel(answer);
        }
    }
}