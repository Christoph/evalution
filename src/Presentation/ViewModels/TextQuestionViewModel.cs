using TheNewEngine.Datalayer;
namespace Presentation
{
    public class TextQuestionViewModel : ViewModelBase
    {
        private readonly TextQuestion mTextQuestion;

        public TextQuestionViewModel(TextQuestion textQuestion)
        {
            this.mTextQuestion = textQuestion;
        }

        public string Question
        {
            get { return mTextQuestion.Question; }
            set
            {
                if (mTextQuestion.Question == value)
                {
                    return;
                }
                mTextQuestion.Question = value;

                OnPropertyChanged("Question");
            }
        }

        public string Text
        {
            get { return mTextQuestion.Text; }
            set
            {
                if (mTextQuestion.Text == value)
                {
                    return;
                }
                mTextQuestion.Text = value;

                OnPropertyChanged("Text");
            }
        }
    }
}