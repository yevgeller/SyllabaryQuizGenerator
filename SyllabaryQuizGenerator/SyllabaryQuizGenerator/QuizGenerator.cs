﻿namespace SyllabaryQuizGenerator
{
    public class QuizGenerator
    {
        public List<QuizItem> GenerateQuizItems()
        {
            return new List<QuizItem>();
        }

        public List<QuizItem> GenerateQuizItems(int number, QuizType quizType = QuizType.EnglishToKatakana, int numberOfPossibleAnswers = 4)
        {
            if (number < 1)
            {
                throw new ArgumentException("Number of quiz items requested must be at least 1");
            }

            if(numberOfPossibleAnswers < 2 || numberOfPossibleAnswers > 6) {
                throw new ArgumentException("Number of possible answers needs to be between 2 and 6");
            }

            List<QuizItem> items = InitializeQuizWithSoManyQuestions(number);

            items = AssignNextQuestionId(items);

            items = AssignQuestions(items, quizType, numberOfPossibleAnswers);

            return items;
        }

        private List<QuizItem> AssignQuestions(List<QuizItem> items, QuizType quizType, int numberOfPossibleAnswers)
        {
            if(quizType == QuizType.EnglishToKatakana)
            {
                return AssignEnglishToKatakanaQuestions(items, numberOfPossibleAnswers);
            }
            if(quizType == QuizType.KatakanaToEnglish)
            {
                return AssignKatakanaToEnglishQuestions(items, numberOfPossibleAnswers);
            }
            return items;
        }

        private List<QuizItem> AssignEnglishToKatakanaQuestions(List<QuizItem> items, int numberOfPossibleAnswers)
        {
            Random rnd = new Random();

            var allChars = Syllabary.GetSyllabaryCharacters();            

            foreach(var i in items)
            {
                SyllabaryCharacter ch = allChars[rnd.Next(allChars.Count())];
                i.Question = ch.Transliteration;
                i.CorrectAnswer = ch.Katakana;
                i.OrdinalNumber = ch.OrdinalNumber;
                i.Answers = Syllabary.GenerateKatakanaAnswers(ch.Katakana, numberOfPossibleAnswers).ToList(); 
            }

            return items;
        }

        private List<QuizItem> AssignKatakanaToEnglishQuestions(List<QuizItem> items, int numberOfPossibleAnswers)
        {
            Random rnd = new Random();

            var allChars = Syllabary.GetSyllabaryCharacters();

            foreach (var i in items)
            {
                SyllabaryCharacter ch = allChars[rnd.Next(allChars.Count())];
                i.Question = ch.Katakana;
                i.CorrectAnswer = ch.Transliteration;
                i.OrdinalNumber = ch.OrdinalNumber;
                i.Answers = Syllabary.GenerateTranslitAnswers(ch.Transliteration, numberOfPossibleAnswers).ToList();
            }

            return items;
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
      

    }
}
