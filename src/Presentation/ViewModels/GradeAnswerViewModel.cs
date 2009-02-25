using Domain;
using TheNewEngine.Datalayer;
namespace Presentation
{
    public class GradeAnswerViewModel : ViewModelBase
    {
        private readonly IGradeAnswer mGradeAnswer;

        public GradeAnswerViewModel(IGradeAnswer gradeAnswer)
        {
            this.mGradeAnswer = gradeAnswer;
        }

        public string Question
        {
            get { return mGradeAnswer.Question.Text; }
            set
            {
                if (mGradeAnswer.Question.Text == value)
                {
                    return;
                }
                mGradeAnswer.Question.Text = value;

                OnPropertyChanged("Question");
            }
        }

        public int? Grade
        {
            get { return mGradeAnswer.Answer; }
            set
            {
                if (mGradeAnswer.Answer == value)
                {
                    return;
                }
                mGradeAnswer.Answer = value;

                OnPropertyChanged("Grade");
            }
        }
    }
}