# SyllabaryQuizGenerator
Generator for questions and answers of Japanese syllabaries. Includes Katakana, Hiragana and transliteration. 

Output is expected as `List<QuizItem>`, with `QuizItem` having the following elements:

```C#
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
```

To get the list of quiz items, call the following method on `SyllabaryQuizGenerator.QuizGenerator`

```C#
public List<QuizItem> GenerateQuizItems(int number,
                                        QuizType quizType = QuizType.TransliterationToKatakana,
                                        int numberOfPossibleAnswers = 4)
```

The project is being published as a package here: https://www.nuget.org/packages/SyllabaryQuizGenerator/

Plans for future:
- Exporting items as JSON
