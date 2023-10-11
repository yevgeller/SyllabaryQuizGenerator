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
            QuizGenerator qg = new QuizGenerator();

            List<QuizItem> quizItems = qg.GenerateQuizItems();

            Assert.IsNotNull(quizItems);
        }


        [TestMethod]
        public void SyllabaryGenerator_ReturnsListOfQuizItems_HasFiveItems()
        {
            QuizGenerator qg = new QuizGenerator();
            int n = 5;
            List<QuizItem> quizItems = qg.GenerateQuizItems(n);
            Assert.IsNotNull(quizItems);
            Assert.IsTrue(quizItems.Count() == n, $"Result does not have {n} items.");
        }

        [TestMethod]
        public void SyllabaryGenerator_ReturnsListOfQuizItems_EachItemHasId()
        {

        }
    }
}