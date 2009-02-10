using System.Collections.ObjectModel;
using TheNewEngine.Datalayer;

namespace Presentation
{
    public class AllFormsViewModel
    {
        private readonly FormRepository mFormRepository;

        public ObservableCollection<FormViewModel> Forms { get; private set; }

        public AllFormsViewModel(FormRepository formRepository)
        {
            mFormRepository = formRepository;
            Forms = new ObservableCollection<FormViewModel>();
        }
    }
}