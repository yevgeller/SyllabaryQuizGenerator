using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyllabaryQuizGenerator.Tests
{
    public partial class QuizGeneratorShould
    {
        [DataRow(3, QuizType.HiraganaToKatakana)]
        [DataRow(5, QuizType.HiraganaToKatakana)]
        [DataRow(500, QuizType.HiraganaToKatakana)]
        [DataRow(50000, QuizType.HiraganaToKatakana)]
        [DataRow(1000000, QuizType.HiraganaToKatakana)]
        [TestMethod]
        public void H2K_ReturnListOfQuizItems_HasRequestedNumberOfItems(int numberOfItems, QuizType quizType)
        {
            List<QuizItem> quizItems = qg.GenerateQuizItems(numberOfItems, quizType);
            Assert.IsNotNull(quizItems);
            Assert.IsTrue(quizItems.Count() == numberOfItems, $"Result does not have {numberOfItems} items.");
        }


        [TestMethod]
        [DataRow(5, QuizType.HiraganaToKatakana)]
        public void H2K_ReturnListOfQuizItems_EachItemHasId(int numberOfItems, QuizType quizType)
        {
            List<QuizItem> quizItems = qg.GenerateQuizItems(numberOfItems, quizType);

            foreach (var qi in quizItems)
            {
                Assert.IsTrue(qi.Id > 0); 
            }
        }

        [DataRow(1000, QuizType.HiraganaToKatakana)]
        [TestMethod]
        public void H2K_GenerateListOfQuizItems_EachItemHasAUniqueId(int numberOfItems, QuizType quizType)
        {
            List<QuizItem> quizItems = qg.GenerateQuizItems(numberOfItems, quizType);
            Dictionary<int, int> dic = new Dictionary<int, int>();
            foreach (var qi in quizItems)
            {
                Assert.IsFalse(dic.ContainsKey(qi.Id), $"QuizItem with Id of {qi.Id} already exists in the collection");
                dic.Add(qi.Id, 1);
            }
        }

        [DataRow(100, QuizType.HiraganaToKatakana)]
        [TestMethod]
        public void H2K_GenerateListOfQuizItems_EachQuizItemHasQuestionType(int numberOfItems, QuizType quizType)
        {
            List<QuizItem> quizItems = qg.GenerateQuizItems(numberOfItems, quizType);
            foreach (var qi in quizItems)
            {
                Assert.IsTrue(qi.QuizType == QuizType.HiraganaToKatakana, $"QuizType is {qi.QuizType}, expected H2K");
            }
        }

        [DataRow(10000, QuizType.HiraganaToKatakana)]
        [TestMethod]
        public void H2K_GenerateListOfQuizItems_EachHasAnOrdinalNumber(int numberOfItems, QuizType quizType)
        {
            List<QuizItem> quizItems = qg.GenerateQuizItems(numberOfItems, quizType);
            foreach (var qi in quizItems)
            {
                Assert.IsTrue(qi.OrdinalNumber > 0, $"Ordinal number of question {qi.Question} is null or a zero");
            }
        }

        [TestMethod]
        [DataRow(10, QuizType.HiraganaToKatakana)]
        public void H2K_GenerateQuiz_EachItemHasNextQuestionId(int numberOfItems, QuizType quizType)
        {
            List<QuizItem> quizItems = qg.GenerateQuizItems(numberOfItems, quizType);
            foreach (var qi in quizItems)
            {
                Assert.IsTrue(qi.NextQuizItemId >= 0, $"Invalid NextQuizItemId: {qi.NextQuizItemId}");
            }
        }

        [TestMethod]
        [DataRow(10000, QuizType.HiraganaToKatakana)]
        public void H2K_GenerateQuiz_EachNextQuestionIdIsUnique(int numberOfItems, QuizType quizType)
        {
            List<QuizItem> quizItems = qg.GenerateQuizItems(numberOfItems, quizType);
            Dictionary<int, int> dic = new Dictionary<int, int>();
            foreach (var qi in quizItems)
            {
                Assert.IsFalse(dic.ContainsKey(qi.NextQuizItemId), $"NextQuizItemId with Id of {qi.NextQuizItemId} already exists in the collection");
                dic.Add(qi.NextQuizItemId, 1);
            }
        }

        [TestMethod]
        [DataRow(10, QuizType.HiraganaToKatakana)]
        [DataRow(100, QuizType.HiraganaToKatakana)]
        [DataRow(1000, QuizType.HiraganaToKatakana)]
        [DataRow(10000, QuizType.HiraganaToKatakana)]
        public void H2K_GenerateQuiz_LastItemNextQuizItemIdIsZero(int numberOfItems, QuizType quizType)
        {
            List<QuizItem> quizItems = qg.GenerateQuizItems(numberOfItems, quizType).ToList();
            var itemsWithNextQuizItemIdOfZero = quizItems.Where(x => x.NextQuizItemId == 0).ToList();
            Assert.IsTrue(itemsWithNextQuizItemIdOfZero.Count() == 1);
            Assert.IsTrue(itemsWithNextQuizItemIdOfZero.First().Id == quizItems.Last().Id);
        }

        [TestMethod]
        [DataRow(10, QuizType.HiraganaToKatakana)]
        public void H2K_GenerateQuiz_QuestionIsNotEmpty(int numberOfItems, QuizType quizType)
        {
            List<QuizItem> quizItems = qg.GenerateQuizItems(numberOfItems, quizType);
            foreach (var qi in quizItems)
            {
                Assert.IsFalse(string.IsNullOrEmpty(qi.Question), $"Question property is null or empty: {qi.Id}");
            }
        }

        [TestMethod]
        [DataRow(10, QuizType.HiraganaToKatakana)]
        public void H2K_GenerateQuiz_QuestionIsHiragana(int numberOfItems, QuizType quizType)
        {
            List<QuizItem> quizItems = qg.GenerateQuizItems(numberOfItems, quizType);
            foreach (var qi in quizItems)
            {
                Assert.IsTrue(Syllabary.IsHiragana(qi.Question!), $"Expected Question in Hiragana, but received {qi.Question}: Question Id: {qi.Id}");
            }
        }

        [TestMethod]
        [DataRow(10, QuizType.HiraganaToKatakana)]
        [DataRow(30, QuizType.HiraganaToKatakana)]
        [DataRow(40, QuizType.HiraganaToKatakana)]
        public void H2K_GenerateQuiz_QuestionsAreRandomForSmallTestQuantities(int numberOfItems, QuizType quizType)
        {
            List<QuizItem> quizItems = qg.GenerateQuizItems(numberOfItems, quizType);
            Dictionary<string, int> dic = new Dictionary<string, int>();
            foreach (var qi in quizItems)
            {
                if (dic.ContainsKey(qi.Question!))
                    dic[qi.Question!]++;
                else
                    dic.Add(qi.Question!, 1);
            }
            Assert.IsTrue(dic.Count() > numberOfItems * 0.5, $"Number of random questions is {dic.Count()} for {numberOfItems} questions requested");
        }

        [TestMethod]
        [DataRow(100, QuizType.HiraganaToKatakana)]
        [DataRow(1000, QuizType.HiraganaToKatakana)]
        [DataRow(10000, QuizType.HiraganaToKatakana)]
        public void H2K_GenerateQuiz_QuestionsAreRandomForLargeTestQuantities(int numberOfItems, QuizType quizType)
        {
            List<QuizItem> quizItems = qg.GenerateQuizItems(numberOfItems, quizType);
            Dictionary<string, int> dic = new Dictionary<string, int>();
            foreach (var qi in quizItems)
            {
                if (dic.ContainsKey(qi.Question!))
                    dic[qi.Question!]++;
                else
                    dic.Add(qi.Question!, 1);
            }

            Assert.IsTrue(dic.Count() > 35, $"Number of random questions is {dic.Count()} for {numberOfItems} questions requested");
        }

        [TestMethod]
        [DataRow(10, QuizType.HiraganaToKatakana)]
        public void H2K_GenerateQuiz_CorrectAnswerIsNotEmpty(int numberOfItems, QuizType quizType)
        {
            var test = qg.GenerateQuizItems(numberOfItems, quizType);
            foreach (var q in test)
            {
                Assert.IsFalse(string.IsNullOrEmpty(q.CorrectAnswer), $"Correct answer is missing: {q.Id}, {q.Question} ");
            }
        }

        [TestMethod]
        [DataRow(10, QuizType.HiraganaToKatakana)]
        public void H2K_GenerateQuiz_CorrectAnswerIsKatakana(int numberOfItems, QuizType quizType)
        {
            var test = qg.GenerateQuizItems(numberOfItems, quizType);
            foreach (var q in test)
            {
                Assert.IsTrue(Syllabary.IsKatakana(q.CorrectAnswer), $"Correct answer is not Katakana for an K2E test: {q.Id}, {q.Question}, {q.CorrectAnswer} ");
            }
        }

        [TestMethod]
        [DataRow(10000, QuizType.HiraganaToKatakana)]
        public void H2K_GenerateQuiz_CorrectAnswerIsCorrectKatakana(int numberOfItems, QuizType quizType)
        {
            var test = qg.GenerateQuizItems(numberOfItems, quizType);
            foreach (var q in test)
            {
                Assert.IsTrue(Syllabary.IsKatakana(q.CorrectAnswer), $"Correct answer is not Transliteration for an K2E test: {q.Id}, {q.Question}, {q.CorrectAnswer} ");
            }
        }

        [TestMethod]
        [DataRow(10000, QuizType.HiraganaToKatakana)]
        public void H2K_GenerateQuiz_OnlyOneOfTheAnswersIsCorrect(int numberOfItems, QuizType quizType)
        {
            var test = qg.GenerateQuizItems(numberOfItems, quizType);
            foreach (var q in test)
            {
                var numberCorrect = q.Answers.Where(x => x == q.CorrectAnswer).Count();
                Assert.AreEqual(1, numberCorrect, $" {numberCorrect} correct answers instead of 1 for {q.Id}, {q.Question}");
            }
        }

        [TestMethod]
        [DataRow(10000, QuizType.HiraganaToKatakana, 2)]
        [DataRow(10000, QuizType.HiraganaToKatakana, 3)]
        [DataRow(10000, QuizType.HiraganaToKatakana, 4)]
        [DataRow(10000, QuizType.HiraganaToKatakana, 5)]
        [DataRow(10000, QuizType.HiraganaToKatakana, 6)]
        public void H2K_GenerateQuiz_CanAdjustTheNumberOfPossibleAnswers(int numberOfItems, QuizType quizType, int possibleAnswersQty)
        {
            var test = qg.GenerateQuizItems(numberOfItems, quizType, possibleAnswersQty);

            foreach (var q in test)
            {
                Assert.AreEqual(possibleAnswersQty, q.Answers.Count(), $" {q.Answers.Count()} possible answers instead of {possibleAnswersQty} for {q.Id}, {q.Question}");
            }
        }

        [TestMethod]
        [DataRow(10, QuizType.HiraganaToKatakana, -100)]
        [DataRow(10, QuizType.HiraganaToKatakana, 0)]
        [DataRow(10, QuizType.HiraganaToKatakana, 1)]
        [DataRow(10, QuizType.HiraganaToKatakana, 7)]
        [DataRow(10, QuizType.HiraganaToKatakana, 100)]
        [ExpectedException(typeof(ArgumentException))]
        public void H2K_AskToGenerateInappropriateNumberOfPossibleAnswers_ReceiveException(int numberOfItems, QuizType quizType, int numberOfPossibleAnswers)
        {
            List<QuizItem> quizItems = qg.GenerateQuizItems(numberOfItems, quizType, numberOfPossibleAnswers);
        }

        [TestMethod]
        [DataRow(50, QuizType.HiraganaToKatakana, 2)]
        [DataRow(50, QuizType.HiraganaToKatakana, 3)]
        [DataRow(50, QuizType.HiraganaToKatakana, 4)]
        [DataRow(50, QuizType.HiraganaToKatakana, 5)]
        [DataRow(50, QuizType.HiraganaToKatakana, 6)]
        public void H2K_GenerateQuiz_CorrectAnswerInRandomPosition(int numberOfItems, QuizType quizType, int possibleAnswersQty)
        {
            var test = qg.GenerateQuizItems(numberOfItems, quizType, possibleAnswersQty);
            Dictionary<int, int> dic = new Dictionary<int, int>();
            foreach (var q in test)
            {
                for (int i = 0; i < q.Answers.Count(); i++)
                {
                    if (q.Answers[i] == q.CorrectAnswer)
                    {
                        if (dic.ContainsKey(i))
                            dic[i]++;
                        else
                            dic.Add(i, 1);
                    }
                }
            }
            Assert.AreEqual(possibleAnswersQty, dic.Keys.Count, $"Correct answers are placed not randomly. Expected {possibleAnswersQty} random positions, but got {dic.Keys.Count}.");
        }

        [TestMethod]
        [DataRow(100, QuizType.HiraganaToKatakana, 6)]
        public void H2K_GenerateQuiz_PossibleAnswersAreNotEmpty(int numberOfItems, QuizType quizType, int possibleAnswersQty)
        {
            var test = qg.GenerateQuizItems(numberOfItems, quizType, possibleAnswersQty);

            foreach (var q in test)
            {
                var countEmpty = q.Answers.Where(x => string.IsNullOrEmpty(x)).Count();
                Assert.AreEqual(0, countEmpty, $"{countEmpty} empty possible answers ");
            }
        }

        [TestMethod]
        [DataRow(100, QuizType.HiraganaToKatakana, 6)]
        public void H2K_GenerateQuiz_PossibleAnswersAreKatakana(int numberOfItems, QuizType quizType, int possibleAnswersQty)
        {
            var test = qg.GenerateQuizItems(numberOfItems, quizType, possibleAnswersQty);

            foreach (var q in test)
            {
                var countWrongSyllabary = q.Answers.Where(x => !Syllabary.IsKatakana(x)).Count();
                Assert.AreEqual(0, countWrongSyllabary, $"{countWrongSyllabary} non-Katakana possible answers ");
            }
        }

        [TestMethod]
        [DataRow(100, QuizType.HiraganaToKatakana, 6)]
        public void H2K_GenerateQuiz_PossibleAnswersNotRepeating(int numberOfItems, QuizType quizType, int possibleAnswersQty)
        {
            var test = qg.GenerateQuizItems(numberOfItems, quizType, possibleAnswersQty);

            foreach (var q in test)
            {
                Dictionary<string, int> dic = new Dictionary<string, int>();
                foreach (var a in q.Answers)
                {
                    Assert.IsTrue(dic.ContainsKey(a) == false, $"Answer {a} is already contained in Question {q.Id}");
                    dic.Add(a, 1);
                }
            }
        }
    }
}
