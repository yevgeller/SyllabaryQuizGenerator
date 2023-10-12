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
            List<QuizItem> quizItems = qg.GenerateQuizItems(numberOfItems);
            Assert.IsNotNull(quizItems);
            Assert.IsTrue(quizItems.Count() == numberOfItems, $"Result does not have {numberOfItems} items.");
        }

        [TestMethod]
        [DataRow(5)]
        public void SyllabaryGenerator_ReturnsListOfQuizItems_EachItemHasId(int numberOfItems)
        {
            List<QuizItem> quizItems = qg.GenerateQuizItems(numberOfItems);

            //List<int> ids = quizItems.Select(x=>x.Id).ToList();

            foreach(var qi in quizItems)
            {
                Assert.IsTrue(qi.Id > 0); //TODO validate property of a collection
            }
            
        }

        [DataRow(1000)]
        [TestMethod]
        public void SyllabaryGenerator_ReturnsListOfQuizItems_EachItemHasAUniqueId(int numberOfItems)
        {
            List<QuizItem> quizItems = qg.GenerateQuizItems(numberOfItems);
            Dictionary<int, int> dic = new Dictionary<int, int>();
            foreach(var qi in quizItems)
            {
                Assert.IsFalse(dic.ContainsKey(qi.Id), $"QuizItem with Id of {qi.Id} already exists in the collection");
                dic.Add(qi.Id, 1);
            }
        }

        [TestMethod]
        [DataRow(-1)]
        [DataRow(0)]
        [DataRow(-1000)]
        [ExpectedException(typeof(ArgumentException))]
        public void SyllabaryGenerator_AskForLessThanThreeQuestions_ReceiveException(int numberOfItems)
        {
            List<QuizItem> quizItems = qg.GenerateQuizItems(numberOfItems);            
        }
    }
}