using System.Data.Linq;
using System.Linq;
using System;

namespace TheNewEngine.Datalayer
{
    public class DatabaseInitializer : IDisposable
    {
        private Db mDb;

        public DatabaseInitializer(string connectionString)
        {
            mDb = new Db(connectionString);
        }

        public void InitDb()
        {
            InsertQuestionSetOne();
        }

        internal void InsertQuestionSetOne()
        {
            var questions = new[]
            {
                "die Doppelhaushälfte",
                "der Filzhut",
                "zögern",
                "böse, teuflisch, lasterhaft",
                "betäubt",
                "die Narbe",
                "in Ehren halten",
                "täuschen",
                "hush",
                "Spur",
                "doubt"
            };

            var translations = questions.Select(
                text => new Question
                {
                    Text = text,
                    AnswerType = (int)AnswerType.Binary,
                    QuestionStage = CreateStages(Stage.Pre, Stage.Post, Stage.DuringWithHelp, Stage.During)
                });
            mDb.Question.InsertAllOnSubmit(translations);

            var songs = questions.Select(
                text => new Question
                {
                    Text = text,
                    AnswerType = (int)(AnswerType.Binary | AnswerType.Song),
                    QuestionStage = CreateStages(Stage.Pre, Stage.Post, Stage.DuringWithHelp, Stage.During)
                });
            mDb.Question.InsertAllOnSubmit(songs);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <filterpriority>2</filterpriority>
        public void Dispose()
        {
            mDb.SubmitChanges();
            mDb.Dispose();
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

            var entities = questions.Select(
                text => new Question
                {
                    Text = text,
                    AnswerType = (int)AnswerType.Grade,
                    QuestionStage = CreateStages(Stage.Pre)
                });
            mDb.Question.InsertAllOnSubmit(entities);
        }

        private static EntitySet<QuestionStage> CreateStages(params Stage[] stages)
        {
            var stagesEntity = new EntitySet<QuestionStage>();
            foreach (var stage in stages)
            {
                stagesEntity.Add(new QuestionStage { StageNumber = (int)stage });    
            }
            return stagesEntity;
        }

        internal void InsertFirstYES_NOQuestions()
        {
            var questions = new[]
            {
                "Was there a song in the first exercise (translation) that you did not know?",
                "Do you have the feeling that today's lesson was valueable as far as your English skills are concerned?",
                "Have you ever looked up parts of song lyrics in a dictionary because you wanted to know what the song was about?"
            };

            var entities = questions.Select(
                text => new Question()
                {
                    Text = text,
                    AnswerType = (int)AnswerType.Binary,
                    QuestionStage = CreateStages(Stage.Pre)
                });
            mDb.Question.InsertAllOnSubmit(entities);
        }

        internal void InsertSecondYES_NOQuestions()
        {
            var questions = new[]
            {
               "Hast du die Lieder der Workshops in der Zwischenzeit zufällig im Radio gehört?",
               "Hast du dich dabei an unseren Workshop erinnert?",
               "Hast du bei dem einen oder anderen Lied, dass du - zufällig oder absichtlich -  gehört hast, an deine neuen Wörtern und ihre Bedeutung gedacht?",
               "Hast du dich an die Bedeutung der Wörter und ihre Übersetzung noch erinnern können?",
            };

            var entities = questions.Select(
                text => new Question()
                {
                    Text = text,
                    AnswerType = (int)AnswerType.Binary,
                    QuestionStage = CreateStages(Stage.During)
                });
            mDb.Question.InsertAllOnSubmit(entities);
        }

        internal void InsertFillInQuestions()
        {
            var questions = new[]
            {
                "Your English book:",
                "The first English song that you knew by heart (think of Kindergarten, primary school, etz):"
            };

            var entities = questions.Select(
                text => new Question()
                {
                    Text = text,
                    AnswerType = (int) AnswerType.Text,
                    QuestionStage = CreateStages(Stage.Pre)

                });
            mDb.Question.InsertAllOnSubmit(entities);
        }
    }
}