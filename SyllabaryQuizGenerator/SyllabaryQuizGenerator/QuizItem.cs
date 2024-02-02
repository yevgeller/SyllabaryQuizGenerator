using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyllabaryQuizGenerator
{
    [DebuggerDisplay("Id:{Id};NextId:{NextQuizItemId}")]
    public class QuizItem
    {
        public int Id { get; set; } = 0;
        public int NextQuizItemId { get; set; } = 0;
        public string? Question { get; set; }
        public int OrdinalNumber { get; set; }
        public QuizType QuizType { get; set; }
        public string? CorrectAnswer { get; set; }
        public List<string> Answers { get; set; } = new List<string>();
    }

    //public class QuizItemV2
    //{
    //    public int Id { get; set; } = 0;
    //    public int NextQuizItemId { get; set; } = 0;
    //    public List<SyllabaryCharacter> Characters { get; set; }
    //}
}
