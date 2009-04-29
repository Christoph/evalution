using System.Windows.Input;
using Domain;
using Domain.Repositories;

namespace Presentation
{
    public class QuestionFormViewModel : ViewModelBase
    {
        private CurrentFormHolder mCurrentFormHolder;

        private Form Form
        {
            get { return mCurrentFormHolder.Form; }
            set { mCurrentFormHolder.Form = value; }
        }

        private readonly IQuestionFormRepository mFormRepository;

        public QuestionFormViewModel(CurrentFormHolder currentFormHolder, 
            IQuestionFormRepository formRepository)
        {
            mCurrentFormHolder = currentFormHolder;
            mFormRepository = formRepository;
        }

        public void Save()
        {
            mFormRepository.Insert(Form);

            OnPropertyChanged("DisplayName");
        }

        public ICommand PreviousCommand
        {
            get
            {
                return new DelegatedCommand(p =>
                {
                    Save();
                    ResetFormTo(mFormRepository.GetPreviousForm(Form.Id));
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

                    var nextForm = mFormRepository.GetNextForm(Form.Id);

                    ResetFormTo(nextForm);
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
                    ResetFormTo(Form);
                });
            }
        }

        private void ResetFormTo(Form form)
        {
            Form = form;
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

        public string Name
        {
            get
            {
                return Form.Name;
            }
            set
            {
                if(Form.Name == value)
                {
                    return;
                }
                Form.Name = value;

                OnPropertyChanged("Name");
            }
        }

        public string School
        {
            get { return Form.School; }
            set
            {
                if (Form.School == value)
                {
                    return;
                }
                Form.School = value;

                OnPropertyChanged("School");
            }
        }

        public string Class
        {
            get { return Form.Class; }
            set
            {
                if (Form.Class == value)
                {
                    return;
                }
                Form.Class = value;

                OnPropertyChanged("Class");
            }
        }

        public int? Age
        {
            get { return Form.Age; }
            set
            {
                if (Form.Age == value)
                {
                    return;
                }
                Form.Age = value;

                OnPropertyChanged("Age");
            }
        }

        public int? Grade
        {
            get { return Form.Grade; }
            set
            {
                if (Form.Grade == value)
                {
                    return;
                }
                Form.Grade = value;

                OnPropertyChanged("Grade");
            }
        }

        public string Instrument
        {
            get { return Form.Instrument; }
            set
            {
                if (Form.Instrument == value)
                {
                    return;
                }
                Form.Instrument = value;

                OnPropertyChanged("Instrument");
            }
        }

        public string Email
        {
            get { return Form.Email; }
            set
            {
                if (Form.Email == value)
                {
                    return;
                }
                Form.Email = value;

                OnPropertyChanged("Email");
            }
        }

        public bool? Gender
        {
            get { return Form.Gender; }
            set
            {
                if (Form.Gender == value)
                {
                    return;
                }
                Form.Gender = value;

                OnPropertyChanged("Gender");
            }
        }
    }
}