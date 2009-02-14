using System.Data.Linq;
using System.Linq;
using System;

namespace TheNewEngine.Datalayer
{
    public class DatabaseInitializer : IDisposable
    {
        public DatabaseInitializer(string connectionString)
        {
        }

        public void InitDb()
        {
            InsertFillInQuestions();
            InsertFirstYES_NOQuestions();
            InsertGradeQuestions();
            InsertQuestionSetOne();
            InsertSecondYES_NOQuestions();
        }

        internal void InsertQuestionSetOne()
        {
            var questions = new[]
            {
                "die Doppelhaush�lfte",
                "der Filzhut",
                "z�gern",
                "b�se, teuflisch, lasterhaft",
                "bet�ubt",
                "die Narbe",
                "in Ehren halten",
                "t�uschen",
                "hush",
                "Spur",
                "doubt"
            };
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <filterpriority>2</filterpriority>
        public void Dispose()
        {
        }

        internal void InsertGradeQuestions()
        {
            var questions = new[]
            {
                "How did you like the project today?",
                "How did you like your teacher?",
                "Do you like acquiring new languages with the help of music?",
                "Do you like music?",
                "Is music a part of your everyday life?",
                "Do your teachers use a lot of music in order to teach you specific things?",
                "Would you appreciate more music in school"
            };
        }

        internal void InsertFirstYES_NOQuestions()
        {
            var questions = new[]
            {
                "Was there a song in the first exercise (translation) that you did not know?",
                "Do you have the feeling that today's lesson was valueable as far as your English skills are concerned?",
                "Have you ever looked up parts of song lyrics in a dictionary because you wanted to know what the song was about?"
            };
        }

        internal void InsertSecondYES_NOQuestions()
        {
            var questions = new[]
            {
               "Hast du die Lieder der Workshops in der Zwischenzeit zuf�llig im Radio geh�rt?",
               "Hast du dich dabei an unseren Workshop erinnert?",
               "Hast du bei dem einen oder anderen Lied, dass du - zuf�llig oder absichtlich -  geh�rt hast, an deine neuen W�rtern und ihre Bedeutung gedacht?",
               "Hast du dich an die Bedeutung der W�rter und ihre �bersetzung noch erinnern k�nnen?",
            };
        }

        internal void InsertFillInQuestions()
        {
            var questions = new[]
            {
                "Your English book:",
                "The first English song that you knew by heart (think of Kindergarten, primary school, etz):"
            };
        }
    }
}