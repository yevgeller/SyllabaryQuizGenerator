namespace SyllabaryQuizGenerator.Tests
{
    [TestClass]
    public class UnitTest1
    {
        QuizGenerator qg;
        [TestInitialize]
        public void SetUpQuizGenerator()
        {
            qg = new QuizGenerator();
        }

        [TestMethod]
        public void SyllabaryGenerator_ReturnsListOfQuizItems_NotNull()
        {
            List<QuizItem> quizItems = qg.GenerateQuizItems();
            Assert.IsNotNull(quizItems);
        }


        [DataRow(5)]
        [TestMethod]
        public void SyllabaryGenerator_ReturnsListOfQuizItems_HasFiveItems(int numberOfItems)
        {
//            int n = 5;
            List<QuizItem> quizItems = qg.GenerateQuizItems(numberOfItems);
            Assert.IsNotNull(quizItems);
            Assert.IsTrue(quizItems.Count() == numberOfItems, $"Result does not have {numberOfItems} items.");
        }

        [TestMethod]
        public void SyllabaryGenerator_ReturnsListOfQuizItems_EachItemHasId()
        {
            int n = 5;
            List<QuizItem> quizItems = qg.GenerateQuizItems(n);
            foreach(var qi in quizItems)
            {
                Assert.IsTrue(qi.Id > 0);
            }
            //CollectionAssert.That.
            //Assert.IsNotNull(quizItems.ForEach(x=>x.Id > 0)
        }

        [DataRow(1000)]
        [TestMethod]
        public void SyllabaryGenerator_ReturnsListOfQuizItems_EachItemHasAUniqueId(int numberOfQuestions)
        {

        }
    }
}