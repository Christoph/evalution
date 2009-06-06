using Domain;
using Domain.Repositories;

namespace Presentation
{
    public class QuestionFormViewModel : ViewModelBase
    {
        private ICurrentFormHolder mCurrentFormHolder;

        private Form Form
        {
            get { return mCurrentFormHolder.Form; }
        }

        private readonly IQuestionFormRepository mFormRepository;

        public QuestionFormViewModel(ICurrentFormHolder currentFormHolder, 
            IQuestionFormRepository formRepository)
        {
            mCurrentFormHolder = currentFormHolder;
            mFormRepository = formRepository;

            mCurrentFormHolder.OnChanged += ResetFormTo;
        }

        private void ResetFormTo(Form form)
        {
            OnPropertyChanged("Name");
            OnPropertyChanged("School");
            OnPropertyChanged("Class");
            OnPropertyChanged("Age");
            OnPropertyChanged("Grade");
            OnPropertyChanged("Instrument");
            OnPropertyChanged("Email");
            OnPropertyChanged("Gender");
        }

        public string Name
        {get
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