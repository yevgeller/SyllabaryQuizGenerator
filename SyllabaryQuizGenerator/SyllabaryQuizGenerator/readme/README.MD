(Project URL) [https://github.com/yevgeller/SyllabaryQuizGenerator/tree/master]

This package generates quizzes for Japanese syllabary. It allows for testing between Katakana, Hiragana, and Transliteration.

Output is expected as List<QuizItem>, with QuizItem having the following elements:

    public class QuizItem
    {
        //unique question id
        public int Id { get; set; } = 0;
        //pointer to the next question
        public int NextQuizItemId { get; set; } = 0;
        //the actual question, string that shows the assignment, what user has to answer correctly
        public string? Question { get; set; }
        //unique number identifying the Syllabary item
        public int OrdinalNumber { get; set; }
        //type of question, of type QuizType
        public QuizType QuizType { get; set; } 
        //correct answer
        public string? CorrectAnswer { get; set; } 
        //list of answers, usually the same type of syllabary
            //(Katakana, Hiragana, or transliteration) as the actual question
        public List<string> Answers { get; set; } = new List<string>();
    }

    //QuizType enum
    public enum QuizType
    {
        TransliterationToHiragana = 0,
        TransliterationToKatakana,
        HiraganaToTransliteration,
        KatakanaToTransliteration,
        HiraganaToKatakana,
        KatakanaToHiragana,
        Random
    }


To get the list of quiz items, call the following method on SyllabaryQuizGenerator.QuizGenerator

    public List<QuizItem> GenerateQuizItems(int number,
                                        QuizType quizType = QuizType.TransliterationToKatakana,
                                        int numberOfPossibleAnswers = 4)