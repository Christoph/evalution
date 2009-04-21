using System.Linq;
using Domain;
using Domain.Repositories;
using System.Collections.Generic;

namespace Presentation
{
    public class AllGradeAnswersViewModel : ViewModelBase
    {
        private readonly IGradeAnswerRepository mGradeAnswerRepository;

        public IEnumerable<GradeAnswerViewModel> Answers { get; private set; }

        public AllGradeAnswersViewModel(Form form, IGradeAnswerRepository gradeAnswerRepository)
        {
            mGradeAnswerRepository = gradeAnswerRepository;
            
            Answers = from answer in mGradeAnswerRepository.CreateFor(form, Stage.Pre)
                select new GradeAnswerViewModel(answer);
        }
    }
}