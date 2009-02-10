using System.Windows.Input;
using TheNewEngine.Datalayer;

namespace Presentation
{
    public class FormViewModel : ViewModelBase
    {
        private readonly Form mForm;

        private readonly FormRepository mFormRepository;

        public FormViewModel(Form form, FormRepository formRepository)
        {
            mForm = form;
            mFormRepository = formRepository;
        }

        public string Name
        {
            get
            {
                return mForm.Name;
            }
            set
            {
                if(mForm.Name == value)
                {
                    return;
                }
                mForm.Name = value;

                OnPropertyChanged("Name");
            }
        }

        public string School
        {
            get { return mForm.School; }
            set
            {
                if (mForm.School == value)
                {
                    return;
                }
                mForm.School = value;

                OnPropertyChanged("School");
            }
        }

        public bool? Gender
        {
            get { return mForm.Gender; }
            set
            {
                if (mForm.Gender == value)
                {
                    return;
                }
                mForm.Gender = value;

                OnPropertyChanged("Gender");
            }
        }

        public void Save()
        {
            mFormRepository.Insert(mForm);

            OnPropertyChanged("DisplayName");
         }

        public ICommand SaveCommand 
        { 
            get
            {
                return new DelegatedCommand(p => Save());
            }
        }
    }
}