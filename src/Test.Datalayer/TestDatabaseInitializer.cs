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

            mDatabaseInitializer = new DatabaseInitializer(mDbName);
        }

        [TearDown]
        public void TearDown()
        {
            mDatabaseInitializer.Dispose();

            try
            {
                var db = new Db(mDbName);

                Assert.AreEqual(mExpectedCount, db.Question.Count());
                Assert.AreEqual(mExpectedStageCount, db.Question.Min(question => question.QuestionStage.Count));
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
            mExpectedCount = 2;
            mExpectedStageCount = 1;
            mDatabaseInitializer.InsertGradeQuestions();
        }
    }
}