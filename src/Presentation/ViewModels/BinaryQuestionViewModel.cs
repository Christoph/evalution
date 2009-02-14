using TheNewEngine.Datalayer;
namespace Presentation
{
    public class BinaryQuestionViewModel : ViewModelBase
    {
        private readonly BinaryQuestion mBinaryQuestion;

        public BinaryQuestionViewModel(BinaryQuestion binaryQuestion)
        {
            mBinaryQuestion = binaryQuestion;
        }

        public BinaryQuestionViewModel(BinaryQuestion binaryQuestion, 
            BinaryQuestionRepository repository)
        {
            mBinaryQuestion = binaryQuestion;
        }
        
        public string Question
        {
            get { return mBinaryQuestion.Question; }
            set
            {
                if (mBinaryQuestion.Question == value)
                {
                    return;
                }
                mBinaryQuestion.Question = value;

                OnPropertyChanged("Question");
            }
        }

        public bool? IsTrue
        {
            get { return mBinaryQuestion.IsTrue; }
            set
            {
                if (mBinaryQuestion.IsTrue == value)
                {
                    return;
                }
                mBinaryQuestion.IsTrue = value;

                OnPropertyChanged("IsTrue");
            }
        }

        public override string ToString()
        {
            return Question;
        }
    }
}