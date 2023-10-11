namespace SyllabaryQuizGenerator.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void SyllabaryGenerator_ReturnsListOfQuizItems()
        {
            QuizGenerator qg = new QuizGenerator();

            List<QuizItem> quizItems = qg.GenerateQuizItems();

            Assert.IsNotNull(quizItems);
        }
    }
}