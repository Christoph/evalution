using Domain.Repositories;
namespace Domain
{
    public class FormFactory : IFormFactory
    {
        private readonly IQuestionFormRepository mQuestionFormRepository;

        private readonly IAnswerRepository[] mAnswerRepositories;

        public FormFactory(IQuestionFormRepository questionFormRepository,
            params IAnswerRepository[] answerRepositories)
        {
            mQuestionFormRepository = questionFormRepository;
            mAnswerRepositories = answerRepositories;
        }

        public Form CreateNew()
        {
            var form = new Form { Id = mQuestionFormRepository.GetNextId() };

            foreach (var repository in mAnswerRepositories)
            {
                repository.CreateFor(form);
            }

            return form;
        }
    }
}