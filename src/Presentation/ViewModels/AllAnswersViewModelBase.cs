using Domain;

namespace Presentation
{
    public abstract class AllAnswersViewModelBase : ViewModelBase
    {
        protected ICurrentFormHolder mCurrentFormHolder;

        protected Stage mStage;

        public string Header { get; private set; }

        public AllAnswersViewModelBase(ICurrentFormHolder currentFormHolder, Stage stage, string header)
        {
            mCurrentFormHolder = currentFormHolder;
            mStage = stage;
            Header = header;

            mCurrentFormHolder.OnChanged += SetAnswers;
        }

        protected abstract void SetAnswers(Form form);
    }
}