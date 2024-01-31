using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyllabaryQuizGenerator.Tests
{
    //Random
    public partial class QuizGeneratorShould
    {
        [DataRow(3, QuizType.Random)]
        [DataRow(5, QuizType.Random)]
        [DataRow(500, QuizType.Random)]
        [DataRow(50000, QuizType.Random)]
        [DataRow(1000000, QuizType.Random)]
        [TestMethod]
        public void RND_ReturnListOfQuizItems_HasRequestedNumberOfItems(int numberOfItems, QuizType quizType)
        {
            List<QuizItem> quizItems = qg!.GenerateQuizItems(numberOfItems, quizType);
            Assert.IsNotNull(quizItems);
            Assert.IsTrue(quizItems.Count() == numberOfItems, $"Result does not have {numberOfItems} items.");
        }


        [TestMethod]
        [DataRow(5, QuizType.Random)]
        public void RND_ReturnListOfQuizItems_EachItemHasId(int numberOfItems, QuizType quizType)
        {
            List<QuizItem> quizItems = qg!.GenerateQuizItems(numberOfItems, quizType);

            foreach (var qi in quizItems)
            {
                Assert.IsTrue(qi.Id > 0);
            }
        }

        [DataRow(1000, QuizType.Random)]
        [TestMethod]
        public void RND_GenerateListOfQuizItems_EachItemHasAUniqueId(int numberOfItems, QuizType quizType)
        {
            List<QuizItem> quizItems = qg!.GenerateQuizItems(numberOfItems, quizType);
            Dictionary<int, int> dic = new Dictionary<int, int>();
            foreach (var qi in quizItems)
            {
                Assert.IsFalse(dic.ContainsKey(qi.Id), $"QuizItem with Id of {qi.Id} already exists in the collection");
                dic.Add(qi.Id, 1);
            }
        }

        [DataRow(10000, QuizType.Random)]
        [TestMethod]
        public void RND_GenerateListOfQuizItems_EachHasAnOrdinalNumber(int numberOfItems, QuizType quizType)
        {
            List<QuizItem> quizItems = qg!.GenerateQuizItems(numberOfItems, quizType);
            foreach (var qi in quizItems)
            {
                Assert.IsTrue(qi.OrdinalNumber > 0, $"Ordinal number of question {qi.Question} is null or a zero");
            }
        }

        [TestMethod]
        [DataRow(10, QuizType.Random)]
        public void RND_GenerateQuiz_EachItemHasNextQuestionId(int numberOfItems, QuizType quizType)
        {
            List<QuizItem> quizItems = qg!.GenerateQuizItems(numberOfItems, quizType);
            foreach (var qi in quizItems)
            {
                Assert.IsTrue(qi.NextQuizItemId >= 0, $"Invalid NextQuizItemId: {qi.NextQuizItemId}");
            }
        }

        [TestMethod]
        [DataRow(10000, QuizType.Random)]
        public void RND_GenerateQuiz_EachNextQuestionIdIsUnique(int numberOfItems, QuizType quizType)
        {
            List<QuizItem> quizItems = qg!.GenerateQuizItems(numberOfItems, quizType);
            Dictionary<int, int> dic = new Dictionary<int, int>();
            foreach (var qi in quizItems)
            {
                Assert.IsFalse(dic.ContainsKey(qi.NextQuizItemId), $"NextQuizItemId with Id of {qi.NextQuizItemId} already exists in the collection");
                dic.Add(qi.NextQuizItemId, 1);
            }
        }

        [TestMethod]
        [DataRow(10, QuizType.Random)]
        [DataRow(100, QuizType.Random)]
        [DataRow(1000, QuizType.Random)]
        [DataRow(10000, QuizType.Random)]
        public void RND_GenerateQuiz_LastItemNextQuizItemIdIsZero(int numberOfItems, QuizType quizType)
        {
            List<QuizItem> quizItems = qg!.GenerateQuizItems(numberOfItems, quizType).ToList();
            var itemsWithNextQuizItemIdOfZero = quizItems.Where(x => x.NextQuizItemId == 0).ToList();
            Assert.IsTrue(itemsWithNextQuizItemIdOfZero.Count() == 1);
            Assert.IsTrue(itemsWithNextQuizItemIdOfZero.First().Id == quizItems.Last().Id);
        }

        [TestMethod]
        [DataRow(10, QuizType.Random)]
        public void RND_GenerateQuiz_QuestionIsNotEmpty(int numberOfItems, QuizType quizType)
        {
            List<QuizItem> quizItems = qg!.GenerateQuizItems(numberOfItems, quizType);
            foreach (var qi in quizItems)
            {
                Assert.IsFalse(string.IsNullOrEmpty(qi.Question), $"Question property is null or empty: {qi.Id}");
            }
        }

        //[TestMethod]
        //[DataRow(10, QuizType.Random)]
        //[DataRow(30, QuizType.Random)]
        //[DataRow(40, QuizType.Random)]
        //public void RND_GenerateQuiz_QuestionsAreRandomForSmallTestQuantities(int numberOfItems, QuizType quizType)
        //{
        //    List<QuizItem> quizItems = qg!.GenerateQuizItems(numberOfItems, quizType);
        //    Dictionary<string, int> dic = new Dictionary<string, int>();
        //    foreach (var qi in quizItems)
        //    {
        //        if (dic.ContainsKey(qi.Question!))
        //            dic[qi.Question!]++;
        //        else
        //            dic.Add(qi.Question!, 1);
        //    }
        //    Assert.IsTrue(dic.Count() > numberOfItems * 0.5, $"Number of random questions is {dic.Count()} for {numberOfItems} questions requested");
        //}

        [TestMethod]
        [DataRow(10000, QuizType.TransliterationToHiragana)]
        public void RND_GenerateQuiz_EnoughT2HQuestions(int numberOfItems, QuizType quizType)
        {
            List<QuizItem> quizItems = qg!.GenerateQuizItems(numberOfItems, quizType);
            int cnt = quizItems.Where(x=>x.QuizType == quizType).Count();

            double percentage = (cnt / numberOfItems) * 100;
            double expectedMin = 100 / 7;

            Assert.IsTrue(percentage > expectedMin, $"Number of T2H questions ({cnt}/10000) is fewer than the min treshold ({expectedMin}%)");
        }

        [TestMethod]
        [DataRow(10000, QuizType.TransliterationToKatakana)]
        public void RND_GenerateQuiz_EnoughT2KQuestions(int numberOfItems, QuizType quizType)
        {
            List<QuizItem> quizItems = qg!.GenerateQuizItems(numberOfItems, quizType);
            int cnt = quizItems.Where(x => x.QuizType == quizType).Count();

            double percentage = (cnt / numberOfItems) * 100;
            double expectedMin = 100 / 7;

            Assert.IsTrue(percentage > expectedMin, $"Number of T2K questions ({cnt}/10000) is fewer than the min treshold ({expectedMin}%)");
        }

        [TestMethod]
        [DataRow(10000, QuizType.HiraganaToTransliteration)]
        public void RND_GenerateQuiz_EnoughH2TQuestions(int numberOfItems, QuizType quizType)
        {
            List<QuizItem> quizItems = qg!.GenerateQuizItems(numberOfItems, quizType);
            int cnt = quizItems.Where(x => x.QuizType == quizType).Count();

            double percentage = (cnt / numberOfItems) * 100;
            double expectedMin = 100 / 7;

            Assert.IsTrue(percentage > expectedMin, $"Number of H2T questions ({cnt}/10000) is fewer than the min treshold ({expectedMin}%)");
        }

        [TestMethod]
        [DataRow(10000, QuizType.KatakanaToTransliteration)]
        public void RND_GenerateQuiz_EnoughK2TQuestions(int numberOfItems, QuizType quizType)
        {
            List<QuizItem> quizItems = qg!.GenerateQuizItems(numberOfItems, quizType);
            int cnt = quizItems.Where(x => x.QuizType == quizType).Count();

            double percentage = (cnt / numberOfItems) * 100;
            double expectedMin = 100 / 7;

            Assert.IsTrue(percentage > expectedMin, $"Number of K2T questions ({cnt}/10000) is fewer than the min treshold ({expectedMin}%)");
        }

        [TestMethod]
        [DataRow(10000, QuizType.HiraganaToKatakana)]
        public void RND_GenerateQuiz_EnoughH2KQuestions(int numberOfItems, QuizType quizType)
        {
            List<QuizItem> quizItems = qg!.GenerateQuizItems(numberOfItems, quizType);
            int cnt = quizItems.Where(x => x.QuizType == quizType).Count();

            double percentage = (cnt / numberOfItems) * 100;
            double expectedMin = 100 / 7;

            Assert.IsTrue(percentage > expectedMin, $"Number of H2K questions ({cnt}/10000) is fewer than the min treshold ({expectedMin}%)");
        }

        [TestMethod]
        [DataRow(10000, QuizType.TransliterationToKatakana)]
        public void RND_GenerateQuiz_EnoughK2HQuestions(int numberOfItems, QuizType quizType)
        {
            List<QuizItem> quizItems = qg!.GenerateQuizItems(numberOfItems, quizType);
            int cnt = quizItems.Where(x => x.QuizType == quizType).Count();

            double percentage = (cnt / numberOfItems) * 100;
            double expectedMin = 100 / 7;

            Assert.IsTrue(percentage > expectedMin, $"Number of K2H questions ({cnt}/10000) is fewer than the min treshold ({expectedMin}%)");
        }

        [TestMethod]
        [DataRow(10, QuizType.Random)]
        public void RND_GenerateQuiz_CorrectAnswerIsNotEmpty(int numberOfItems, QuizType quizType)
        {
            var test = qg!.GenerateQuizItems(numberOfItems, quizType);
            foreach (var q in test)
            {
                Assert.IsFalse(string.IsNullOrEmpty(q.CorrectAnswer), $"Correct answer is missing: {q.Id}, {q.Question} ");
            }
        }
        

        [TestMethod]
        [DataRow(10000, QuizType.Random)]
        public void RND_GenerateQuiz_OnlyOneOfTheAnswersIsCorrect(int numberOfItems, QuizType quizType)
        {
            var test = qg!.GenerateQuizItems(numberOfItems, quizType);
            foreach (var q in test)
            {
                var numberCorrect = q.Answers.Where(x => x == q.CorrectAnswer).Count();
                Assert.AreEqual(1, numberCorrect, $" {numberCorrect} correct answers instead of 1 for {q.Id}, {q.Question}");
            }
        }

        [TestMethod]
        [DataRow(10000, QuizType.Random, 2)]
        [DataRow(10000, QuizType.Random, 3)]
        [DataRow(10000, QuizType.Random, 4)]
        [DataRow(10000, QuizType.Random, 5)]
        [DataRow(10000, QuizType.Random, 6)]
        public void RND_GenerateQuiz_CanAdjustTheNumberOfPossibleAnswers(int numberOfItems, QuizType quizType, int possibleAnswersQty)
        {
            var test = qg!.GenerateQuizItems(numberOfItems, quizType, possibleAnswersQty);

            foreach (var q in test)
            {
                Assert.AreEqual(possibleAnswersQty, q.Answers.Count(), $" {q.Answers.Count()} possible answers instead of {possibleAnswersQty} for {q.Id}, {q.Question}");
            }
        }

        [TestMethod]
        [DataRow(10, QuizType.Random, -100)]
        [DataRow(10, QuizType.Random, 0)]
        [DataRow(10, QuizType.Random, 1)]
        [DataRow(10, QuizType.Random, 7)]
        [DataRow(10, QuizType.Random, 100)]
        [ExpectedException(typeof(ArgumentException))]
        public void RND_AskToGenerateInappropriateNumberOfPossibleAnswers_ReceiveException(int numberOfItems, QuizType quizType, int numberOfPossibleAnswers)
        {
            List<QuizItem> quizItems = qg!.GenerateQuizItems(numberOfItems, quizType, numberOfPossibleAnswers);
        }

        [TestMethod]
        [DataRow(50, QuizType.Random, 2)]
        [DataRow(50, QuizType.Random, 3)]
        [DataRow(50, QuizType.Random, 4)]
        [DataRow(50, QuizType.Random, 5)]
        [DataRow(50, QuizType.Random, 6)]
        public void RND_GenerateQuiz_CorrectAnswerInRandomPosition(int numberOfItems, QuizType quizType, int possibleAnswersQty)
        {
            var test = qg!.GenerateQuizItems(numberOfItems, quizType, possibleAnswersQty);
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
        [DataRow(100, QuizType.Random, 6)]
        public void RND_GenerateQuiz_PossibleAnswersAreNotEmpty(int numberOfItems, QuizType quizType, int possibleAnswersQty)
        {
            var test = qg!.GenerateQuizItems(numberOfItems, quizType, possibleAnswersQty);

            foreach (var q in test)
            {
                var countEmpty = q.Answers.Where(x => string.IsNullOrEmpty(x)).Count();
                Assert.AreEqual(0, countEmpty, $"{countEmpty} empty possible answers ");
            }
        }

        [TestMethod]
        [DataRow(100, QuizType.Random, 6)]
        public void RND_GenerateQuiz_PossibleAnswersNotRepeating(int numberOfItems, QuizType quizType, int possibleAnswersQty)
        {
            var test = qg!.GenerateQuizItems(numberOfItems, quizType, possibleAnswersQty);

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
