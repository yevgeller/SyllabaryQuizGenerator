using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyllabaryQuizGenerator
{
    internal class QuizItem
    {
        public int Id { get; set; } = 0;
        public int NextQuizItemId { get; set; } = 1;
        public string Question { get; set; } = "?";
        public QuizType QuestionType { get; set; }
        public string CorrectAnswer { get; set; } = "!";
        public List<string> Answers { get; set; } = new List<string>();
    }
}
