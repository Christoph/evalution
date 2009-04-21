using Domain;

namespace Presentation
{
    public class TextAnswerViewModel : ViewModelBase
    {
        private readonly TextAnswer mTextAnswer;

        public TextAnswerViewModel(TextAnswer textAnswer)
        {
            mTextAnswer = textAnswer;
        }

        public string Question
        {
            get { return mTextAnswer.Question.Text; }
            set
            {
                if (mTextAnswer.Question.Text == value)
                {
                    return;
                }
                mTextAnswer.Question.Text = value;

                OnPropertyChanged("Question");
            }
        }

        public string Text
        {
            get { return mTextAnswer.Answer; }
            set
            {
                if (mTextAnswer.Answer == value)
                {
                    return;
                }
                mTextAnswer.Answer = value;

                OnPropertyChanged("Text");
            }
        }
    }
}