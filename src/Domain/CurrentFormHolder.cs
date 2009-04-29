using System;

namespace Domain
{
    public class CurrentFormHolder
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

        public CurrentFormHolder(IFormFactory formFactory)
        {
            mFormFactory = formFactory;
            ResetWithNewForm();
        }

        public void ResetWithNewForm()
        {
            mForm = mFormFactory.CreateNew();
        }
    }
}