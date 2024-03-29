﻿namespace SyllabaryQuizGenerator
{
    public class QuizGenerator
    {
        public List<QuizItem> GenerateQuizItems()
        {
            return new List<QuizItem>();
        }

        public List<QuizItem> GenerateQuizItems(int number, QuizType quizType = QuizType.TransliterationToKatakana, int numberOfPossibleAnswers = 4)
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

        public List<SyllabaryCharacter> GetAllSyllabaryCharacters()
        {
            return Syllabary.GetSyllabaryCharacters();
        }

        private List<QuizItem> AssignQuestions(List<QuizItem> items, QuizType quizType, int numberOfPossibleAnswers)
        {
            if(quizType == QuizType.TransliterationToKatakana)
            {
                return AssignTransliterationToKatakanaQuestions(items, numberOfPossibleAnswers);
            }
            if(quizType == QuizType.KatakanaToTransliteration)
            {
                return AssignKatakanaToTransliterationQuestions(items, numberOfPossibleAnswers);
            }
            if (quizType == QuizType.TransliterationToHiragana)
            {
                return AssignTransliterationToHiraganaQuestions(items, numberOfPossibleAnswers);
            }
            if (quizType == QuizType.HiraganaToKatakana)
            {
                return AssignHiraganaToKatakanaQuestions(items, numberOfPossibleAnswers);
            }
            if(quizType == QuizType.HiraganaToTransliteration)
            {
                return AssignHiraganaToTransliterationQuestions(items, numberOfPossibleAnswers);
            }
            if(quizType == QuizType.KatakanaToHiragana)
            {
                return AssignKatakanaToHiraganaQuestions(items, numberOfPossibleAnswers);
            }
            if(quizType == QuizType.Random)
            {
                return AssignRandomQuestions(items, numberOfPossibleAnswers);
            }
            return items;
        }

        private List<QuizItem> AssignRandomQuestions(List<QuizItem> items, int numberOfPossibleAnswers)
        {
            for(int i = 0; i < items.Count(); i++) 
            {
                Random rnd = new Random();
                QuizType randomlyPickedQuizType = (QuizType)rnd.Next(6);
                List<QuizItem> thisOneItemList = new List<QuizItem>
                    {
                        new QuizItem { Id = items[i].Id, NextQuizItemId = items[i].Id }
                    };
                QuizItem thisOneQuestion = AssignQuestions(thisOneItemList, randomlyPickedQuizType, numberOfPossibleAnswers)[0];

                items[i].Question = thisOneQuestion.Question;
                items[i].OrdinalNumber = thisOneQuestion.OrdinalNumber; 
                for(int answerPosition = 0;  answerPosition < thisOneQuestion.Answers.Count(); answerPosition++)
                {
                    items[i].Answers.Add(thisOneQuestion.Answers[answerPosition]);
                }
                items[i].QuizType = thisOneQuestion.QuizType;
                items[i].CorrectAnswer = thisOneQuestion.CorrectAnswer;
            }

            return items;
        }

        private List<QuizItem> AssignKatakanaToHiraganaQuestions(List<QuizItem> items, int numberOfPossibleAnswers)
        {
            Random rnd = new Random();

            var allChars = Syllabary.GetSyllabaryCharacters();

            foreach (var i in items)
            {
                SyllabaryCharacter ch = allChars[rnd.Next(allChars.Count())];
                i.Question = ch.Katakana;
                i.CorrectAnswer = ch.Hiragana;
                i.OrdinalNumber = ch.UniqueId;
                i.Answers = Syllabary.GenerateAnswers(Syllabary.GetRandomHiragana, ch.Hiragana, numberOfPossibleAnswers).ToList();
                i.QuizType = QuizType.KatakanaToHiragana;
            }

            return items;
        }

        private List<QuizItem> AssignHiraganaToTransliterationQuestions(List<QuizItem> items, int numberOfPossibleAnswers)
        {
            Random rnd = new Random();

            var allChars = Syllabary.GetSyllabaryCharacters();

            foreach (var i in items)
            {
                SyllabaryCharacter ch = allChars[rnd.Next(allChars.Count())];
                i.Question = ch.Hiragana;
                i.CorrectAnswer = ch.Transliteration;
                i.OrdinalNumber = ch.UniqueId;
                i.Answers = Syllabary.GenerateAnswers(Syllabary.GetRandomTransliteration, ch.Transliteration, numberOfPossibleAnswers).ToList();
                i.QuizType = QuizType.HiraganaToTransliteration;
            }

            return items;
        }

        private List<QuizItem> AssignHiraganaToKatakanaQuestions(List<QuizItem> items, int numberOfPossibleAnswers)
        {
            Random rnd = new Random();

            var allChars = Syllabary.GetSyllabaryCharacters();

            foreach (var i in items)
            {
                SyllabaryCharacter ch = allChars[rnd.Next(allChars.Count())];
                i.Question = ch.Hiragana;
                i.CorrectAnswer = ch.Katakana;
                i.OrdinalNumber = ch.UniqueId;
                i.Answers = Syllabary.GenerateAnswers(Syllabary.GetRandomKatakana, ch.Katakana, numberOfPossibleAnswers).ToList();
                i.QuizType = QuizType.HiraganaToKatakana;
            }

            return items;
        }

        private List<QuizItem> AssignTransliterationToKatakanaQuestions(List<QuizItem> items, int numberOfPossibleAnswers)
        {
            Random rnd = new Random();

            var allChars = Syllabary.GetSyllabaryCharacters();            

            foreach(var i in items)
            {
                SyllabaryCharacter ch = allChars[rnd.Next(allChars.Count())];
                i.Question = ch.Transliteration;
                i.CorrectAnswer = ch.Katakana;
                i.OrdinalNumber = ch.UniqueId;
                i.Answers = Syllabary.GenerateAnswers(Syllabary.GetRandomKatakana, ch.Katakana, numberOfPossibleAnswers).ToList();
                i.QuizType = QuizType.TransliterationToKatakana;
            }

            return items;
        }

        private List<QuizItem> AssignKatakanaToTransliterationQuestions(List<QuizItem> items, int numberOfPossibleAnswers)
        {
            Random rnd = new Random();

            var allChars = Syllabary.GetSyllabaryCharacters();

            foreach (var i in items)
            {
                SyllabaryCharacter ch = allChars[rnd.Next(allChars.Count())];
                i.Question = ch.Katakana;
                i.CorrectAnswer = ch.Transliteration;
                i.OrdinalNumber = ch.UniqueId;
                i.Answers = Syllabary.GenerateAnswers(Syllabary.GetRandomTransliteration, ch.Transliteration, numberOfPossibleAnswers).ToList();
                i.QuizType = QuizType.KatakanaToTransliteration;
            }

            return items;
        }
        private List<QuizItem> AssignTransliterationToHiraganaQuestions(List<QuizItem> items, int numberOfPossibleAnswers)
        {
            Random rnd = new Random();

            var allChars = Syllabary.GetSyllabaryCharacters();

            foreach (var i in items)
            {
                SyllabaryCharacter ch = allChars[rnd.Next(allChars.Count())];
                i.Question = ch.Transliteration;
                i.CorrectAnswer = ch.Hiragana;
                i.OrdinalNumber = ch.UniqueId;
                i.Answers = Syllabary.GenerateAnswers(Syllabary.GetRandomHiragana, ch.Hiragana,  numberOfPossibleAnswers).ToList();
                i.QuizType = QuizType.TransliterationToHiragana;
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
