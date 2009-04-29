using Domain.Repositories;
namespace Domain
{
    public class FormFactory : IFormFactory
    {
        private readonly IAnswerRepository<BinaryAnswer> mBinaryAnswerRepository;

        public FormFactory(IAnswerRepository<BinaryAnswer> binaryAnswerRepository)
        {
            mBinaryAnswerRepository = binaryAnswerRepository;
        }

        public Form CreateNew()
        {
            var form = new Form();
            mBinaryAnswerRepository.CreateFor(form);

            return form;
        }
    }
}