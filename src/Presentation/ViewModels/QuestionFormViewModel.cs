using System.Linq;
using System.Windows.Input;
using Domain;
using Domain.Repositories;

namespace Presentation
{
    public class QuestionFormViewModel : ViewModelBase
    {
        private Form mForm;

        private readonly IQuestionFormRepository mFormRepository;

        public QuestionFormViewModel(Form form, IQuestionFormRepository formRepository)
        {
            mForm = form;
            mFormRepository = formRepository;

            var forms = mFormRepository.GetAll();
            if (forms.Count() != 0)
            {
                mForm = forms.First();
            }
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

        public string Class
        {
            get { return mForm.Class; }
            set
            {
                if (mForm.Class == value)
                {
                    return;
                }
                mForm.Class = value;

                OnPropertyChanged("Class");
            }
        }

        public int? Age
        {
            get { return mForm.Age; }
            set
            {
                if (mForm.Age == value)
                {
                    return;
                }
                mForm.Age = value;

                OnPropertyChanged("Age");
            }
        }

        public int? Grade
        {
            get { return mForm.Grade; }
            set
            {
                if (mForm.Grade == value)
                {
                    return;
                }
                mForm.Grade = value;

                OnPropertyChanged("Grade");
            }
        }

        public string Instrument
        {
            get { return mForm.Instrument; }
            set
            {
                if (mForm.Instrument == value)
                {
                    return;
                }
                mForm.Instrument = value;

                OnPropertyChanged("Instrument");
            }
        }

        public string Email
        {
            get { return mForm.Email; }
            set
            {
                if (mForm.Email == value)
                {
                    return;
                }
                mForm.Email = value;

                OnPropertyChanged("Email");
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

        public ICommand PreviousCommand
        {
            get
            {
                return new DelegatedCommand(p =>
                {
                    Save();
                    ResetFormTo(mFormRepository.GetPreviousForm(mForm.Id));
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
                    ResetFormTo(mFormRepository.GetNextForm(mForm.Id));
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
                    ResetFormTo(new Form());
                });
            }
        }

        private void ResetFormTo(Form form)
        {
            mForm = form;
            OnPropertyChanged("Name");
            OnPropertyChanged("School");
            OnPropertyChanged("Class");
            OnPropertyChanged("Age");
            OnPropertyChanged("Grade");
            OnPropertyChanged("Instrument");
            OnPropertyChanged("Email");
            OnPropertyChanged("Gender");
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