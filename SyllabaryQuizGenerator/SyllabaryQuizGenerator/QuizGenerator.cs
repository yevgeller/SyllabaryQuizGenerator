using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyllabaryQuizGenerator
{
    public class QuizGenerator
    {
        public List<QuizItem> GenerateQuizItems()
        {
            return new List<QuizItem>();
        }

        //Generate so many quiz items
        public List<QuizItem> GenerateQuizItems(int number)
        {
            if (number < 1)
            {
                throw new ArgumentException("Number of quiz items requested must be at least 1");
            }

            List<QuizItem> items = new List<QuizItem>(number);

            for (int i = 0; i < number; i++)
            {
                items.Add(new QuizItem { Id = i + 1 });
            }

            for (int i = items.Count() - 1; i > 0; i--)
            {
                items[i - 1].NextQuizItemId = items[i].Id;
            }

            items[0].NextQuizItemId = items[1].Id;

            return items;
        }

        //Generate so many quiz items of a kind, test all six kinds
    }
}
