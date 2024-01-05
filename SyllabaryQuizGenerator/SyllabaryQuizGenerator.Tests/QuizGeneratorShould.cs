namespace SyllabaryQuizGenerator.Tests
{
    [TestClass]
    public partial class QuizGeneratorShould
    {
        QuizGenerator qg;
        [TestInitialize]
        public void Setup()
        {
            qg = new QuizGenerator();
        }

        [TestMethod]
        public void ReturnListOfQuizItems_NotNull()
        {
            List<QuizItem> quizItems = qg.GenerateQuizItems();
            Assert.IsNotNull(quizItems);
        }
        
        [TestMethod]
        [DataRow(-1)]
        [DataRow(0)]
        [DataRow(-1000)]
        [ExpectedException(typeof(ArgumentException))]
        public void AskToGenerateLessThanThreeQuestions_ReceiveException(int numberOfItems)
        {
            List<QuizItem> quizItems = qg.GenerateQuizItems(numberOfItems);
        }
    }
}