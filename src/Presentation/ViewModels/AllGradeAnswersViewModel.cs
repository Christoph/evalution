using System.Linq;
using Domain;
using Domain.Repositories;
using System.Collections.Generic;

namespace Presentation
{
    public class AllGradeAnswersViewModel : ViewModelBase
    {
        private readonly IAnswerRepository<GradeAnswer> mGradeAnswerRepository;

        public IEnumerable<GradeAnswerViewModel> Answers { get; private set; }

        public AllGradeAnswersViewModel(Form form, IAnswerRepository<GradeAnswer> gradeAnswerRepository)
        {
            mGradeAnswerRepository = gradeAnswerRepository;
            
            Answers = from answer in mGradeAnswerRepository.CreateFor(form)
                select new GradeAnswerViewModel(answer);
        }
    }
}