using Domain;

namespace Presentation
{
    public class BinaryAnswerViewModel : ViewModelBase
    {
        private readonly BinaryAnswer mBinaryAnswer;

        public BinaryAnswerViewModel(BinaryAnswer binaryAnswer)
        {
            mBinaryAnswer = binaryAnswer;
        }

        public string Question
        {
            get { return mBinaryAnswer.Question.Text; }
            set
            {
                if (mBinaryAnswer.Question.Text == value)
                {
                    return;
                }
                mBinaryAnswer.Question.Text = value;

                OnPropertyChanged("Question");
            }
        }

        public bool? Answer
        {
            get { return mBinaryAnswer.Answer; }
            set
            {
                if (mBinaryAnswer.Answer == value)
                {
                    return;
                }
                mBinaryAnswer.Answer = value;

                OnPropertyChanged("Answer");
            }
        }
    }
}