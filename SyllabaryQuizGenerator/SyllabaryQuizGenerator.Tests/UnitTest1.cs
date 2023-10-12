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

            foreach (var qi in quizItems)
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
            foreach (var qi in quizItems)
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

        [TestMethod]
        [DataRow(10)]
        public void SyllabaryGenerator_RequestQuiz_EachItemHasNextQuestionId(int numberOfItems)
        {
            List<QuizItem> quizItems = qg.GenerateQuizItems(numberOfItems);
            foreach (var qi in quizItems)
            {
                Assert.IsTrue(qi.NextQuizItemId >= 0, $"Invalid NextQuizItemId: {qi.NextQuizItemId}");
            }
        }

        [TestMethod]
        [DataRow(10000)]
        public void SyllabaryGenerator_RequestQuiz_EachNextQuestionIdIsUnique(int numberOfItems)
        {
            List<QuizItem> quizItems = qg.GenerateQuizItems(numberOfItems);
            Dictionary<int, int> dic = new Dictionary<int, int>();
            foreach (var qi in quizItems)
            {
                Assert.IsFalse(dic.ContainsKey(qi.NextQuizItemId), $"NextQuizItemId with Id of {qi.NextQuizItemId} already exists in the collection");
                dic.Add(qi.NextQuizItemId, 1);
            }
        }

        [TestMethod]
        [DataRow(10000)]
        public void SyllabaryGenerator_RequestQuiz_LastItemNextQuizItemIdIsZero(int numberOfItems)
        {
            List<QuizItem> quizItems = qg.GenerateQuizItems(numberOfItems).ToList();
            var itemsWithNextQuizItemIdOfZero = quizItems.Where(x => x.NextQuizItemId == 0).ToList();
            Assert.IsTrue(itemsWithNextQuizItemIdOfZero.Count() == 1); //TODO: needed? I'm already checking for unique NextQuizItemId
            Assert.IsTrue(itemsWithNextQuizItemIdOfZero.First().Id == quizItems.Last().Id);
        }
    }
}