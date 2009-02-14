using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using TheNewEngine.Datalayer;
namespace Presentation
{
    public class AllBinaryQuestionsViewModel : ViewModelBase
    {
        private readonly BinaryQuestionRepository mQuestionRepository;

        public ObservableCollection<BinaryQuestionViewModel> Questions { get; private set; }

        public AllBinaryQuestionsViewModel(BinaryQuestionRepository questionRepository)
        {
            mQuestionRepository = questionRepository;

            var all = from q in mQuestionRepository.GetAll()
                select new BinaryQuestionViewModel(q, mQuestionRepository);

            foreach (BinaryQuestionViewModel viewModel in all)
            {
                viewModel.PropertyChanged += OnBinaryQuestionViewModelPropertyChanged;
            }

            Questions = new ObservableCollection<BinaryQuestionViewModel>(all);
            Questions.CollectionChanged += OnCollectionChanged;
        }

        protected override void OnDispose()
        {
            foreach (BinaryQuestionViewModel viewModel in Questions)
            {
                viewModel.Dispose();
            }

            Questions.Clear();
            Questions.CollectionChanged -= OnCollectionChanged;

            //mQuestionRepository.OnQuestionAnswered -= this.OnQuestionAnswered;
        }

        void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null && e.NewItems.Count != 0)
            {
                foreach (BinaryQuestionViewModel viewModel in e.NewItems)
                {
                    viewModel.PropertyChanged += OnBinaryQuestionViewModelPropertyChanged;
                }
            }

            if (e.OldItems != null && e.OldItems.Count != 0)
            {
                foreach (BinaryQuestionViewModel viewModel in e.OldItems)
                {
                    viewModel.PropertyChanged -= OnBinaryQuestionViewModelPropertyChanged;
                }
            }
        }

        void OnBinaryQuestionViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            
        }
    }
}