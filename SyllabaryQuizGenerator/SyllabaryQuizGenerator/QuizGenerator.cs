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
        { List<QuizItem> items = new List<QuizItem>(number);
            for (int i = 0; i < number; i++)
            {
                items.Add(new QuizItem());
            }
            return items;
        }
        
        //Generate so many quiz items of a kind, test all six kinds
    }
}
