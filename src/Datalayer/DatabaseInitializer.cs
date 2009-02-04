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

        public void InsertGradeQuestions()
        {
            var questions = new[]
            {
                "How did you like the project today?",
                "How did you like your teacher?"
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
    }
}