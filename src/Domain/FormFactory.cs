using Domain.Repositories;
namespace Domain
{
    public class FormFactory : IFormFactory
    {
        private readonly IAnswerRepository<BinaryAnswer> mBinaryAnswerRepository;

        private readonly IAnswerRepository<BinaryAnswer> mSongAnswerRepository;

        public FormFactory(IAnswerRepository<BinaryAnswer> binaryAnswerRepository, IAnswerRepository<BinaryAnswer> songAnswerRepository)
        {
            mBinaryAnswerRepository = binaryAnswerRepository;
            mSongAnswerRepository = songAnswerRepository;
        }

        public Form CreateNew()
        {
            var form = new Form();
            mBinaryAnswerRepository.CreateFor(form);
            mSongAnswerRepository.CreateFor(form);

            return form;
        }
    }
}