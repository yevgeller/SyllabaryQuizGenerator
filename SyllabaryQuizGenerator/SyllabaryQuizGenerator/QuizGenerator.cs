using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SyllabaryQuizGenerator
{
    public class QuizGenerator
    {
        public List<QuizItem> GenerateQuizItems()
        {
            return new List<QuizItem>();
        }

        public List<QuizItem> GenerateQuizItems(int number, QuizType quizType = QuizType.EnglishToKatakana)
        {
            if (number < 1)
            {
                throw new ArgumentException("Number of quiz items requested must be at least 1");
            }

            List<QuizItem> items = InitializeQuizWithSoManyQuestions(number);

            items = AssignNextQuestionId(items);

            items = AssignQuestions(items, quizType);

            return items;
        }

        private List<QuizItem> AssignQuestions(List<QuizItem> items, QuizType quizType)
        {
            if(quizType == QuizType.EnglishToKatakana)
            {
                return AssignEnglishToKatakanaQuestions(items);
            }
            return items;
        }

        private List<QuizItem> AssignEnglishToKatakanaQuestions(List<QuizItem> items)
        {
            throw new NotImplementedException();
        }

        private List<QuizItem> InitializeQuizWithSoManyQuestions(int numberOfQuestions)
        {
            List<QuizItem> items = new List<QuizItem>(numberOfQuestions);

            for (int i = 0; i < numberOfQuestions; i++)
            {
                items.Add(new QuizItem { Id = i + 1, Question = "?" });
            }

            return items;
        }

        private List<QuizItem> AssignNextQuestionId(List<QuizItem> items)
        {
            for (int i = items.Count() - 1; i > 0; i--)
            {
                items[i - 1].NextQuizItemId = items[i].Id;
            }

            items[0].NextQuizItemId = items[1].Id;

            return items;
        }
        //Generate so many quiz items of a kind, test all six kinds
        //public List<QuizItem> GenerateQuizItems(int number, QuizType quizType)
        //{
        //    var result = this.GenerateQuizItems(number);

        //    return result;
        //}
    }
}
