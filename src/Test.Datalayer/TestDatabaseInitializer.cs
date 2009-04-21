using System.IO;
using System.Linq;
using MbUnit.Framework;
using NHibernate;
using Domain;

namespace TheNewEngine.Datalayer
{
    public class TestDatabaseInitializer
    {
        private string mDbName;

        private DatabaseInitializer mDatabaseInitializer;

        private int mExpectedCount;

        private int mExpectedStageCount;

        private ISession mSession;
        
        [SetUp]
        public void Setup()
        {
            mDbName = "TestDatabaseInitializer.sdf";
            File.Copy(@"..\EmptyDb.sdf", mDbName);
            mSession = DbAccess.GetSessionForEmptyDatabase(mDbName);
            mDatabaseInitializer = new DatabaseInitializer(mSession);
        }

        [TearDown]
        public void TearDown()
        {
            try
            {
                var session = DbAccess.CreateNewSession();
                var list = session.CreateCriteria(typeof(Question)).List();
                Assert.AreEqual(mExpectedCount, list.Count);
                Assert.AreEqual(mExpectedStageCount, list.Cast<Question>().Min(question => question.QuestionStages.Count));
                mDatabaseInitializer.Dispose();
            }
            finally
            {
                File.Delete(mDbName);   
            }
        }

        [Test]
        public void InsertQuestionSetOne()
        {
            mExpectedCount = 22;
            mExpectedStageCount = 4;
            mDatabaseInitializer.InsertQuestionSetOne();
            mSession.Close();
        }

        [Test]
        public void InsertGradeQuestions()
        {
            mExpectedCount = 7;
            mExpectedStageCount = 1;
            mDatabaseInitializer.InsertGradeQuestions();
        }

        [Test]
        public void InsertFirstYES_NOQuestions()
        {
            mExpectedCount = 3;
            mExpectedStageCount = 1;
            mDatabaseInitializer.InsertFirstYES_NOQuestions();
        }

        [Test]
        public void InsertFillInQuestions()
        {
            mExpectedCount = 2;
            mExpectedStageCount = 1;
            mDatabaseInitializer.InsertFillInQuestions();
        }

        [Test]
        public void InsertSecondYES_NOQuestions()
        {
            mExpectedCount = 4;
            mExpectedStageCount = 1;
            mDatabaseInitializer.InsertSecondYES_NOQuestions();
        }
    }
}