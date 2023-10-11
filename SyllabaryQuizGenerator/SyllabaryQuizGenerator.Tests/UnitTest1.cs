namespace SyllabaryQuizGenerator.Tests
{
    [TestClass]
    public class UnitTest1
    {
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
    }
}