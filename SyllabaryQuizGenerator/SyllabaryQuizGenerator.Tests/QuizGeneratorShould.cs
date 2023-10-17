namespace SyllabaryQuizGenerator.Tests
{
    [TestClass]
    public class QuizGeneratorShould
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


        [DataRow(3)]
        [DataRow(5)]
        [DataRow(500)]
        [DataRow(50000)]
        [DataRow(1000000)]
        [TestMethod]
        public void ReturnListOfQuizItems_HasRequestedNumberOfItems(int numberOfItems)
        {
            List<QuizItem> quizItems = qg.GenerateQuizItems(numberOfItems);
            Assert.IsNotNull(quizItems);
            Assert.IsTrue(quizItems.Count() == numberOfItems, $"Result does not have {numberOfItems} items.");
        }

        [TestMethod]
        [DataRow(5)]
        public void ReturnListOfQuizItems_EachItemHasId(int numberOfItems)
        {
            List<QuizItem> quizItems = qg.GenerateQuizItems(numberOfItems);

            foreach (var qi in quizItems)
            {
                Assert.IsTrue(qi.Id > 0); //TODO validate property of a collection
            }

        }

        [DataRow(1000)]
        [TestMethod]
        public void GenerateListOfQuizItems_EachItemHasAUniqueId(int numberOfItems)
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
        public void AskToGenerateLessThanThreeQuestions_ReceiveException(int numberOfItems)
        {
            List<QuizItem> quizItems = qg.GenerateQuizItems(numberOfItems);
        }

        [TestMethod]
        [DataRow(10)]
        public void GenerateQuiz_EachItemHasNextQuestionId(int numberOfItems)
        {
            List<QuizItem> quizItems = qg.GenerateQuizItems(numberOfItems);
            foreach (var qi in quizItems)
            {
                Assert.IsTrue(qi.NextQuizItemId >= 0, $"Invalid NextQuizItemId: {qi.NextQuizItemId}");
            }
        }

        [TestMethod]
        [DataRow(10000)]
        public void GenerateQuiz_EachNextQuestionIdIsUnique(int numberOfItems)
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
        [DataRow(10)]
        [DataRow(100)]
        [DataRow(1000)]
        [DataRow(10000)]
        public void GenerateQuiz_LastItemNextQuizItemIdIsZero(int numberOfItems)
        {
            List<QuizItem> quizItems = qg.GenerateQuizItems(numberOfItems).ToList();
            var itemsWithNextQuizItemIdOfZero = quizItems.Where(x => x.NextQuizItemId == 0).ToList();
            Assert.IsTrue(itemsWithNextQuizItemIdOfZero.Count() == 1); //TODO: needed? I'm already checking for unique NextQuizItemId
            Assert.IsTrue(itemsWithNextQuizItemIdOfZero.First().Id == quizItems.Last().Id);
        }

        [TestMethod]
        [DataRow(10)]
        public void GenerateQuiz_QuestionIsNotEmpty(int numberOfItems)
        {
            List<QuizItem> quizItems = qg.GenerateQuizItems(numberOfItems);
            foreach (var qi in quizItems)
            {
                Assert.IsFalse(string.IsNullOrEmpty(qi.Question), $"Question property is null or empty: {qi.Id}");
            }
        }

        [TestMethod]
        [DataRow(10, QuizType.EnglishToKatakana)]
        public void GenerateEnglishToKatakanaQuiz_QuestionIsEnglish(int numberOfItems, QuizType quizType)
        {
            List<QuizItem> quizItems = qg.GenerateQuizItems(numberOfItems, quizType);
            foreach (var qi in quizItems)
            {
                Assert.IsTrue(Syllabary.Syllabary.IsTransliteration(qi.Question), $"Expected Question in English, but received {qi.Question}: Question Id: {qi.Id}");
            }
        }

        [TestMethod]
        [DataRow(10)]
        [DataRow(30)]
        [DataRow(40)]
        public void GenerateEnglishToKatakanaQuiz_QuestionsAreRandomForSmallTestQuantities(int numberOfItems)
        {
            List<QuizItem> quizItems = qg.GenerateQuizItems(numberOfItems);
            Dictionary<string, int> dic = new Dictionary<string, int>();
            foreach (var qi in quizItems)
            {
                if (dic.ContainsKey(qi.Question))
                    dic[qi.Question]++;
                else
                    dic.Add(qi.Question, 1);
            }
            Assert.IsTrue(dic.Count() > numberOfItems * 0.5, $"Number of random questions is {dic.Count()} for {numberOfItems} questions requested");
        }

        [TestMethod]
        [DataRow(100)]
        [DataRow(1000)]
        [DataRow(10000)]
        public void GenerateEnglishToKatakanaQuiz_QuestionsAreRandomForLargeTestQuantities(int numberOfItems)
        {
            List<QuizItem> quizItems = qg.GenerateQuizItems(numberOfItems);
            Dictionary<string, int> dic = new Dictionary<string, int>();
            foreach (var qi in quizItems)
            {
                if (dic.ContainsKey(qi.Question))
                    dic[qi.Question]++;
                else
                    dic.Add(qi.Question, 1);
            }

            Assert.IsTrue(dic.Count() > 35, $"Number of random questions is {dic.Count()} for {numberOfItems} questions requested");
        }

        [TestMethod]
        [DataRow(10)]
        public void GenerateEnglishToKatakanaQuiz_CorrectAnswerIsNotEmpty(int numberOfItems)
        {
            var test = qg.GenerateQuizItems(numberOfItems);
            foreach(var q in test)
            {
                Assert.IsFalse(string.IsNullOrEmpty(q.CorrectAnswer), $"Correct answer is missing: {q.Id}, {q.Question} ");
            }
        }

        [TestMethod]
        [DataRow(10)]
        public void GenerateEnglishToKatakanaQuiz_CorrectAnswerIsKatakana(int numberOfItems)
        {
            var test = qg.GenerateQuizItems(numberOfItems);
            foreach (var q in test)
            {
                Assert.IsTrue(Syllabary.Syllabary.IsKatakana(q.CorrectAnswer), $"Correct answer is not Katakana for an E2K test: {q.Id}, {q.Question} ");
            }
        }

        [TestMethod]
        [DataRow(10000)]
        public void GenerateEnglishToKatakanaQuiz_CorrectAnswerIsCorrectKatakana(int numberOfItems)
        {
            var test = qg.GenerateQuizItems(numberOfItems);
            foreach (var q in test)
            {
                Assert.IsTrue(Syllabary.Syllabary.IsKatakana(q.CorrectAnswer), $"Correct answer is not Katakana for an E2K test: {q.Id}, {q.Question} ");
            }
        }

        [TestMethod]
        [DataRow(10000)]
        public void GenerateEnglishToKatakanaQuiz_OnlyOneOfTheAnswersIsCorrect(int numberOfItems)
        {
            var test = qg.GenerateQuizItems(numberOfItems);
            foreach (var q in test)
            {
                var numberCorrect = q.Answers.Where(x => x == q.CorrectAnswer).Count();
                Assert.AreEqual(1, numberCorrect, $" {numberCorrect} correct answers instead of 1 for {q.Id}, {q.Question}");
            }
        }
    }
}