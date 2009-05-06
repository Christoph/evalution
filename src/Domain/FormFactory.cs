using Domain.Repositories;
namespace Domain
{
    public class FormFactory : IFormFactory
    {
        private readonly IAnswerRepository[] mAnswerRepositories;

        public FormFactory(params IAnswerRepository[] answerRepositories)
        {
            mAnswerRepositories = answerRepositories;
        }

        public Form CreateNew()
        {
            var form = new Form();

            foreach (var repository in mAnswerRepositories)
            {
                repository.CreateFor(form);
            }

            return form;
        }
    }
}