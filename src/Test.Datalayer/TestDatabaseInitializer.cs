using System.IO;
using System.Linq;
using MbUnit.Framework;

namespace TheNewEngine.Datalayer
{
    public class TestDatabaseInitializer
    {
        private string mDbName;

        private DatabaseInitializer mDatabaseInitializer;

        private int mExpectedCount;

        private int mExpectedStageCount;
        
        [SetUp]
        public void Setup()
        {
            mDbName = "TestDatabaseInitializer.sdf";
            File.Copy("Db.sdf", mDbName);
            var session = DbAccess.GetSessionForEmptyDatabase(mDbName);
            mDatabaseInitializer = new DatabaseInitializer(session);
        }

        [TearDown]
        public void TearDown()
        {
            try
            {
                mDatabaseInitializer.Dispose();


                //                var db = new Db(mDbName);
//
//                Assert.AreEqual(mExpectedCount, db.Question.Count());
//                Assert.AreEqual(mExpectedStageCount, db.Question.Min(question => question.QuestionStage.Count));
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