using System.Collections.Generic;
using System.Linq;
using System;
using Domain;
using NHibernate;

namespace TheNewEngine.Datalayer
{
    public class DatabaseInitializer : IDisposable
    {
        private readonly ISession mSession;

        public DatabaseInitializer(ISession session)
        {
            mSession = session;
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
                    QuestionStages = CreateStages(Stage.Pre, Stage.Post, Stage.DuringWithHelp, Stage.During)
                });
            SaveList(translations);

            var songs = questions.Select(
                text => new Question
                {
                    Text = text,
                    AnswerType = (int)(AnswerType.Song),
                    QuestionStages = CreateStages(Stage.Pre, Stage.Post, Stage.DuringWithHelp, Stage.During)
                });
            SaveList(songs);
            mSession.Flush();
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
                    QuestionStages = CreateStages(Stage.Pre)
                });
            SaveList(entities);
            mSession.Flush();
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
                text => new Question
                {
                    Text = text,
                    AnswerType = (int)AnswerType.Binary,
                    QuestionStages = CreateStages(Stage.PreYesNo)
                });
            SaveList(entities);
            mSession.Flush();
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
                text => new Question
                {
                    Text = text,
                    AnswerType = (int)AnswerType.Binary,
                    QuestionStages = CreateStages(Stage.DuringYesNo)
                });
            SaveList(entities);
            mSession.Flush();
        }

        internal void InsertFillInQuestions()
        {
            var questions = new[]
            {
                "Your English book:",
                "The first English song that you knew by heart (think of Kindergarten, primary school, etz):"
            };

            var entities = questions.Select(
                text => new Question
                {
                    Text = text,
                    AnswerType = (int) AnswerType.Text,
                    QuestionStages = CreateStages(Stage.Pre)
                });
            SaveList(entities);
            mSession.Flush();
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <filterpriority>2</filterpriority>
        public void Dispose()
        {
            mSession.Dispose();
        }

        private void SaveList<T>(IEnumerable<T> list)
        {
            foreach (var element in list)
            {
                mSession.Save(element);
            }
        }

        private List<QuestionStage> CreateStages(params Stage[] stages)
        {
            var stagesEntity = new List<QuestionStage>();
            foreach (var stage in stages)
            {
                var questionStage = new QuestionStage { StageNumber = stage };
                mSession.SaveOrUpdate(questionStage);
                stagesEntity.Add(questionStage);
            }
            return stagesEntity;
        }
    }
}