using Domain.Repositories;
namespace Domain
{
    public class FormFactory : IFormFactory
    {
        private readonly IBinaryAnswerRepository mBinaryAnswerRepository;

        public FormFactory(IBinaryAnswerRepository binaryAnswerRepository)
        {
            mBinaryAnswerRepository = binaryAnswerRepository;
        }

        public Form CreateNew()
        {
            var form = new Form();
            mBinaryAnswerRepository.CreateFor(form, Stage.Pre);

            return form;
        }
    }
}