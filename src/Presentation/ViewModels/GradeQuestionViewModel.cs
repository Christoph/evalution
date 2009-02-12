using TheNewEngine.Datalayer;
namespace Presentation
{
    public class GradeAnswerViewModel : ViewModelBase
    {
        private readonly GradeQuestion mGradeQuestion;

        public GradeAnswerViewModel(GradeQuestion gradeQuestion)
        {
            this.mGradeQuestion = gradeQuestion;
        }

        public string Question
        {
            get { return mGradeQuestion.Question; }
            set
            {
                if (mGradeQuestion.Question == value)
                {
                    return;
                }
                mGradeQuestion.Question = value;

                OnPropertyChanged("Question");
            }
        }

        public int Grade
        {
            get { return mGradeQuestion.Grade; }
            set
            {
                if (mGradeQuestion.Grade == value)
                {
                    return;
                }
                mGradeQuestion.Grade = value;

                OnPropertyChanged("Grade");
            }
        }
    }
}