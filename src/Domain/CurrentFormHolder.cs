using System;

namespace Domain
{
    public class CurrentFormHolder : ICurrentFormHolder
    {
        private readonly IFormFactory mFormFactory;

        private Form mForm;

        public Form Form
        {
            get { return mForm; }
            set
            {
                mForm = value;
                if(mForm == null)
                {
                    ResetWithNewForm();
                }

                if (OnChanged != null)
                {
                    OnChanged(mForm);
                }
            }
        }

        public event Action<Form> OnChanged;

        public CurrentFormHolder(Form form, IFormFactory formFactory)
        {
            mFormFactory = formFactory;
            Form = form;
        }

        public void ResetWithNewForm()
        {
            Form = mFormFactory.CreateNew();
        }
    }
}