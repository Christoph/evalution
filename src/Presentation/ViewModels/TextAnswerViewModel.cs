using Domain;
using TheNewEngine.Datalayer;
namespace Presentation
{
    public class TextAnswerViewModel : ViewModelBase
    {
        private readonly ITextAnswer mTextAnswer;

        public TextAnswerViewModel(ITextAnswer textAnswer)
        {
            this.mTextAnswer = textAnswer;
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