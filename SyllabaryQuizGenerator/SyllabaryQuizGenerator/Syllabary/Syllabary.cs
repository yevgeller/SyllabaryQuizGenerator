namespace SyllabaryQuizGenerator
{
    public static class Syllabary
    {
        //string hiragana = "あ い う え お か が き ぎ く ぐ け げ こ ご さ ざ し じ す ず せ ぜ そ ぞ た だ ち ぢ っ つ づ て で と ど な に ぬ ね の は ば ぱ ひ び ぴ ふ ぶ ぷ へ べ ぺ ほ ぼ ぽ ま み む め も ゃ や ゅ ゆ ょ よ ら り る れ ろ ゎ わ ゐ ゑ を ん ゔ ゕ ゖ゛゜ゝゞゟ";
        //string katakana = "ア イ ウ エ オ カ ガ キ ギ ク グ ケ ゲ コ ゴ サ ザ シ ジ ス ズ セ ゼ ソ ゾ タ ダ チ ヂ ッ ツ ヅ テ デ ト ド ナ ニ ヌ ネ ノ ハ バ パ ヒ ビ ピ フ ブ プ ヘ ベ ペ ホ ボ ポ マ ミ ム メ モ ャ ヤ ュ ユ ョ ヨ ラ リ ル レ ロ ヮ ワ ヰ ヱ ヲ ン ヴ ヵ ヶ ヷ ヸ ヹ ヺ ・ ー ヽ ヾ ヿ";
        //string hiragana = "  ぜ そ ぞ た だ ち ぢ っ つ づ て で と ど な に ぬ ね の は ば ぱ ひ び ぴ ふ ぶ ぷ へ べ ぺ ほ ぼ ぽ ま み む め も ゃ や ゅ ゆ ょ よ ら り る れ ろ ゎ わ ゐ ゑ を ん ゔ ゕ ゖ゛゜ゝゞゟ";
        //string katakana = "  ゼ ソ ゾ タ ダ チ ヂ ッ ツ ヅ テ デ ト ド ナ ニ ヌ ネ ノ ハ バ パ ヒ ビ ピ フ ブ プ ヘ ベ ペ ホ ボ ポ マ ミ ム メ モ ャ ヤ ュ ユ ョ ヨ ラ リ ル レ ロ ヮ ワ ヰ ヱ ヲ ン ヴ ヵ ヶ ヷ ヸ ヹ ヺ ・ ー ヽ ヾ ヿ";
        static List<string> hiragana = "あ い う え お か が き ぎ く ぐ け げ こ ご さ ざ し じ す ず せ ぜ そ ぞ た だ ち ぢ っ つ づ て で と ど な に ぬ ね の は ば ぱ ひ び ぴ ふ ぶ ぷ へ べ ぺ ほ ぼ ぽ ま み む め も ゃ や ゅ ゆ ょ よ ら り る れ ろ ゎ わ ゐ ゑ を ん ゔ".Split(' ').ToList<string>();
        static List<string> katakana = "ア イ ウ エ オ カ ガ キ ギ ク グ ケ ゲ コ ゴ サ ザ シ ジ ス ズ セ ゼ ソ ゾ タ ダ チ ヂ ッ ツ ヅ テ デ ト ド ナ ニ ヌ ネ ノ ハ バ パ ヒ ビ ピ フ ブ プ ヘ ベ ペ ホ ボ ポ マ ミ ム メ モ ャ ヤ ュ ユ ョ ヨ ラ リ ル レ ロ ヮ ワ ヰ ヱ ヲ ン ヴ".Split(' ').ToList<string>();
        static List<string> translit = "a i u e o ka ga ki gi ku gu ke ge ko go sa za shi ji su zu se ze so zo ta da chi ji tsu zu te de to do na ni nu ne no ha ba pa hi bi pi fu bu pu he be pe ho bo po ma mi mu me mo ya yu yo".Split(' ').ToList<string>();
        public static List<SyllabaryCharacter> GetSyllabaryCharacters()
        {
            List<SyllabaryCharacter> result = new List<SyllabaryCharacter>
            {
                new SyllabaryCharacter { UniqueId=1, Hiragana = "あ", Katakana = "ア", Transliteration = "a" },
                new SyllabaryCharacter { UniqueId=2, Hiragana = "い", Katakana = "イ", Transliteration = "i" },
                new SyllabaryCharacter { UniqueId=3, Hiragana = "う", Katakana = "ウ", Transliteration = "u" },
                new SyllabaryCharacter { UniqueId=4, Hiragana = "え", Katakana = "エ", Transliteration = "e" },
                new SyllabaryCharacter { UniqueId=5, Hiragana = "お", Katakana = "オ", Transliteration = "o" },
                new SyllabaryCharacter { UniqueId=6, Hiragana = "か", Katakana = "カ", Transliteration = "ka" },
                new SyllabaryCharacter { UniqueId=7, Hiragana = "が", Katakana = "ガ", Transliteration = "ga" },
                new SyllabaryCharacter { UniqueId=8, Hiragana = "き", Katakana = "キ", Transliteration = "ki" },
                new SyllabaryCharacter { UniqueId=9, Hiragana = "ぎ", Katakana = "ギ", Transliteration = "gi" },
                new SyllabaryCharacter { UniqueId=10, Hiragana = "く", Katakana = "ク", Transliteration = "ku" },
                new SyllabaryCharacter { UniqueId=11, Hiragana = "ぐ", Katakana = "グ", Transliteration = "gu" },
                new SyllabaryCharacter { UniqueId=12, Hiragana = "け", Katakana = "ケ", Transliteration = "ke" },
                new SyllabaryCharacter { UniqueId=13, Hiragana = "げ", Katakana = "ゲ", Transliteration = "ge" },
                new SyllabaryCharacter { UniqueId=14, Hiragana = "こ", Katakana = "コ", Transliteration = "ko" },
                new SyllabaryCharacter { UniqueId=15, Hiragana = "ご", Katakana = "ゴ", Transliteration = "go" },
                new SyllabaryCharacter { UniqueId=16, Hiragana = "さ", Katakana = "サ", Transliteration = "sa" },
                new SyllabaryCharacter { UniqueId=17, Hiragana = "ざ", Katakana = "ザ", Transliteration = "za" },
                new SyllabaryCharacter { UniqueId=18, Hiragana = "し", Katakana = "シ", Transliteration = "shi" },
                new SyllabaryCharacter { UniqueId=19, Hiragana = "じ", Katakana = "ジ", Transliteration = "ji" },
                new SyllabaryCharacter { UniqueId=20, Hiragana = "す", Katakana = "ス", Transliteration = "su" },
                new SyllabaryCharacter { UniqueId=21, Hiragana = "ず", Katakana = "ズ", Transliteration = "zu" },
                new SyllabaryCharacter { UniqueId=22, Hiragana = "せ", Katakana = "セ", Transliteration = "se" },

                new SyllabaryCharacter { UniqueId = 23,Hiragana = "ぜ", Katakana = "ゼ", Transliteration = "ze" },
                new SyllabaryCharacter { UniqueId = 24,Hiragana = "そ", Katakana = "ソ", Transliteration = "so" },
                new SyllabaryCharacter { UniqueId = 25,Hiragana = "ぞ", Katakana = "ゾ", Transliteration = "zo" },
                new SyllabaryCharacter { UniqueId = 26,Hiragana = "た", Katakana = "タ", Transliteration = "ta" },
                new SyllabaryCharacter { UniqueId = 27,Hiragana = "だ", Katakana = "ダ", Transliteration = "da" },
                new SyllabaryCharacter { UniqueId = 28,Hiragana = "ち", Katakana = "チ", Transliteration = "chi" },
                new SyllabaryCharacter { UniqueId = 29,Hiragana = "ぢ", Katakana = "ヂ", Transliteration = "ji" },
                new SyllabaryCharacter { UniqueId = 30,Hiragana = "つ", Katakana = "ツ", Transliteration = "tsu" },
                new SyllabaryCharacter { UniqueId = 31,Hiragana = "づ", Katakana = "ヅ", Transliteration = "zu" },
                new SyllabaryCharacter { UniqueId = 32,Hiragana = "て", Katakana = "テ", Transliteration = "te" },
                new SyllabaryCharacter { UniqueId = 33,Hiragana = "で", Katakana = "デ", Transliteration = "de" },
                new SyllabaryCharacter { UniqueId = 34,Hiragana = "と", Katakana = "ト", Transliteration = "to" },
                new SyllabaryCharacter { UniqueId = 35,Hiragana = "ど", Katakana = "ド", Transliteration = "do" },
                new SyllabaryCharacter { UniqueId = 36,Hiragana = "な", Katakana = "ナ", Transliteration = "na" },
                new SyllabaryCharacter { UniqueId = 37,Hiragana = "に", Katakana = "ニ", Transliteration = "ni" },
                new SyllabaryCharacter { UniqueId = 38,Hiragana = "ぬ", Katakana = "ヌ", Transliteration = "nu" },
                new SyllabaryCharacter { UniqueId = 39,Hiragana = "ね", Katakana = "ネ", Transliteration = "ne" },
                new SyllabaryCharacter { UniqueId = 40,Hiragana = "の", Katakana = "ノ", Transliteration = "no" },
                new SyllabaryCharacter { UniqueId = 41,Hiragana = "は", Katakana = "ハ", Transliteration = "ha" },
                new SyllabaryCharacter { UniqueId = 42,Hiragana = "ば", Katakana = "バ", Transliteration = "ba" },
                new SyllabaryCharacter { UniqueId = 43,Hiragana = "ぱ", Katakana = "パ", Transliteration = "pa" },
                new SyllabaryCharacter { UniqueId = 44,Hiragana = "ひ", Katakana = "ヒ", Transliteration = "hi" },
                new SyllabaryCharacter { UniqueId = 45,Hiragana = "び", Katakana = "ビ", Transliteration = "bi" },
                new SyllabaryCharacter { UniqueId = 46,Hiragana = "ぴ", Katakana = "ピ", Transliteration = "pi" },
                new SyllabaryCharacter { UniqueId = 47,Hiragana = "ふ", Katakana = "フ", Transliteration = "fu" },
                new SyllabaryCharacter { UniqueId = 48,Hiragana = "ぶ", Katakana = "ブ", Transliteration = "bu" },
                new SyllabaryCharacter { UniqueId = 49,Hiragana = "ぷ", Katakana = "プ", Transliteration = "pu" },
                new SyllabaryCharacter { UniqueId = 50,Hiragana = "へ", Katakana = "ヘ", Transliteration = "he" },
                new SyllabaryCharacter { UniqueId = 51,Hiragana = "べ", Katakana = "ベ", Transliteration = "be" },
                new SyllabaryCharacter { UniqueId = 52,Hiragana = "ぺ", Katakana = "ペ", Transliteration = "pe" },
                new SyllabaryCharacter { UniqueId = 53,Hiragana = "ほ", Katakana = "ホ", Transliteration = "ho" },
                new SyllabaryCharacter { UniqueId = 54,Hiragana = "ぼ", Katakana = "ボ", Transliteration = "bo" },
                new SyllabaryCharacter { UniqueId = 55,Hiragana = "ぽ", Katakana = "ポ", Transliteration = "po" },
                new SyllabaryCharacter { UniqueId = 56,Hiragana = "ま", Katakana = "マ", Transliteration = "ma" },
                new SyllabaryCharacter { UniqueId = 57,Hiragana = "み", Katakana = "ミ", Transliteration = "mi" },
                new SyllabaryCharacter { UniqueId = 58,Hiragana = "む", Katakana = "ム", Transliteration = "mu" },
                new SyllabaryCharacter { UniqueId = 59,Hiragana = "め", Katakana = "メ", Transliteration = "me" },
                new SyllabaryCharacter { UniqueId = 60,Hiragana = "も", Katakana = "モ", Transliteration = "mo" },
                new SyllabaryCharacter { UniqueId = 61,Hiragana = "や", Katakana = "ヤ", Transliteration = "ya" },
                new SyllabaryCharacter { UniqueId = 62,Hiragana = "ゆ", Katakana = "ユ", Transliteration = "yu" },
                new SyllabaryCharacter { UniqueId = 63,Hiragana = "よ", Katakana = "ヨ", Transliteration = "yo" }

            };

            //result.Add(new SyllabaryCharacter { Hiragana = "ら", Katakana = "ラ", Transliteration = "" });
            //result.Add(new SyllabaryCharacter { Hiragana = "り", Katakana = "リ", Transliteration = "" });
            //result.Add(new SyllabaryCharacter { Hiragana = "る", Katakana = "ル", Transliteration = "" });
            //result.Add(new SyllabaryCharacter { Hiragana = "れ", Katakana = "レ", Transliteration = "" });
            //result.Add(new SyllabaryCharacter { Hiragana = "ろ", Katakana = "ロ", Transliteration = "" });
            //result.Add(new SyllabaryCharacter { Hiragana = "わ", Katakana = "ワ", Transliteration = "" });
            //result.Add(new SyllabaryCharacter { Hiragana = "を", Katakana = "ヲ", Transliteration = "" }); 
            //result.Add(new SyllabaryCharacter { Hiragana = "ん", Katakana = "ン", Transliteration = "" });
            return result;
        }

        public static bool IsHiragana(string syllable)
        {
            return hiragana.Contains(syllable); //TODO: switch to numbers something 
        }

        public static bool IsKatakana(string syllable)
        {
            return katakana.Contains(syllable);
        }

        public static bool IsTransliteration(string syllable)
        {
            return translit.Where(x => x == syllable).Any();
        }

        public static SyllabaryCharacter FindBySomething(string what)
        {
            var ret =  GetSyllabaryCharacters().Where(x => x.Katakana == what || x.Hiragana == what || x.Transliteration == what).FirstOrDefault();
            if(ret != null) return ret;

            return new SyllabaryCharacter();
        }

        public static IEnumerable<string> GenerateKatakanaAnswers(string correctAnswer, int possibleAnswers)
        {
            string[] answers = Enumerable.Repeat(correctAnswer, possibleAnswers).ToArray();
            Random rnd = new Random();
            int correctPosition = rnd.Next(possibleAnswers);
            for (int i = 0; i < possibleAnswers; i++)
            {
                if (i == correctPosition)
                    continue;

                string candidate = correctAnswer;
                do
                {
                    candidate = GetRandomKatakana();
                } while (answers.Contains(candidate));

                answers[i] = candidate;
            }
            return answers;
        }

        public static string GetRandomKatakana()
        {
            Random rnd = new Random();
            return katakana[rnd.Next(katakana.Count())];
        }

        public static string GetRandomHiragana()
        {
            Random rnd = new Random();
            return hiragana[rnd.Next(hiragana.Count())];
        }

        public static IEnumerable<string> GenerateAnswers(Func<string> GetRandomCharacter, string correctAnswer, int possibleAnswers)
        {
            string[] answers = Enumerable.Repeat(correctAnswer, possibleAnswers).ToArray();
            Random rnd = new Random();
            int correctPosition = rnd.Next(possibleAnswers);
            for (int i = 0; i < possibleAnswers; i++)
            {
                if (i == correctPosition)
                    continue;

                string candidate = correctAnswer;
                do
                {
                    candidate = GetRandomCharacter();
                } while (answers.Contains(candidate));

                answers[i] = candidate;
            }
            return answers;
        }

        public static string GetRandomSyllabaryCharacter(SyllabaryType syllabaryType)
        {
            Random rnd = new Random();
            if (syllabaryType == SyllabaryType.Katakana)
            {
                return katakana[rnd.Next(katakana.Count())];
            }
            if (syllabaryType == SyllabaryType.Hiragana)
            {
                return hiragana[rnd.Next(hiragana.Count())];
            }
            return translit[rnd.Next(translit.Count())];
        }

        public static string GetRandomTransliteration()
        {
            Random rnd = new Random();
            return translit[rnd.Next(translit.Count())];
        } 

        //public static List<string> AllKatakanaCharacters()
        //{
        //    var syllabary = Syllabary.GetSyllabaryCharacters();
        //    var result = syllabary.Select(x => x.Katakana).ToList();
        //    return result;
        //}

        //public static List<string> AllHiraganaCharacters()
        //{
        //    var syllabary = Syllabary.GetSyllabaryCharacters();
        //    var result = syllabary.Select(x => x.Hiragana).ToList();
        //    return result;
        //}

        //public static List<string> AllTransliterationCharacters()
        //{
        //    var syllabary = Syllabary.GetSyllabaryCharacters();
        //    var result = syllabary.Select(x => x.Transliteration).ToList();
        //    return result;
        //}
    }
}