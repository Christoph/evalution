using System.Windows.Input;
using Domain;
using Domain.Repositories;

namespace Presentation
{
    public class ButtonsViewModel : ViewModelBase
    {
        private ICurrentFormHolder mCurrentFormHolder;

        private IQuestionFormRepository mFormRepository;

        public ButtonsViewModel(ICurrentFormHolder currentFormHolder, 
            IQuestionFormRepository formRepository)
        {
            mCurrentFormHolder = currentFormHolder;
            mFormRepository = formRepository;

            UpdateHasPreviosAndHasNext(mCurrentFormHolder.Form);
            mCurrentFormHolder.OnChanged += UpdateHasPreviosAndHasNext;
        }

        private Form Form
        {
            get { return mCurrentFormHolder.Form; }
            set { mCurrentFormHolder.Form = value; }
        }
        
        private void Save()
        {
            mFormRepository.Insert(Form);
        }

        public ICommand PreviousCommand
        {
            get
            {
                return new DelegatedCommand(p =>
                {
                    Save();
                    Form = mFormRepository.GetPreviousForm(Form.Id);
                });
            }
        }

        public ICommand NextCommand
        {
            get
            {
                return new DelegatedCommand(p =>
                {
                    Save();
                    Form = mFormRepository.GetNextForm(Form.Id);
                });
            }
        }

        public ICommand NewCommand
        {
            get
            {
                return new DelegatedCommand(p =>
                {
                    Save();
                    mCurrentFormHolder.ResetWithNewForm();
                });
            }
        }


        private void UpdateHasPreviosAndHasNext(Form form)
        {
            HasPrevious = mFormRepository.HasPrevious(form.Id);
            HasNext = mFormRepository.HasNext(form.Id);
        }

        private bool mHasPrevious;

        public bool HasPrevious
        {
            get { return mHasPrevious; }
            set
            {
                mHasPrevious = value;
                OnPropertyChanged("HasPrevious");
            }
        }

        private bool mHasNext;

        public bool HasNext
        {
            get { return mHasNext; }
            set
            {
                mHasNext = value;
                OnPropertyChanged("HasNext");
            }
        }
    }
}