using System.Linq;
using Domain.Repositories;
using System.Collections.Generic;
namespace Presentation
{
    public class AllGradeAnswersViewModel : ViewModelBase
    {
        private readonly IGradeAnswerRepository mGradeAnswerRepository;

        public IEnumerable<GradeAnswerViewModel> Answers { get; private set; }

        public AllGradeAnswersViewModel(IGradeAnswerRepository gradeAnswerRepository)
        {
            mGradeAnswerRepository = gradeAnswerRepository;

            Answers = from answer in mGradeAnswerRepository.GetAll()
                select new GradeAnswerViewModel(answer);
        }
    }
}