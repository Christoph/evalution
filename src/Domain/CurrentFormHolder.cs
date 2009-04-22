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
            }
        }

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