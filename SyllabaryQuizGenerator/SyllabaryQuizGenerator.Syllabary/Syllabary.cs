using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SyllabaryQuizGenerator.Syllabary
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
                new SyllabaryCharacter { Hiragana = "あ", Katakana = "ア", Transliteration = "a" },
                new SyllabaryCharacter { Hiragana = "い", Katakana = "イ", Transliteration = "i" },
                new SyllabaryCharacter { Hiragana = "う", Katakana = "ウ", Transliteration = "u" },
                new SyllabaryCharacter { Hiragana = "え", Katakana = "エ", Transliteration = "e" },
                new SyllabaryCharacter { Hiragana = "お", Katakana = "オ", Transliteration = "o" },
                new SyllabaryCharacter { Hiragana = "か", Katakana = "カ", Transliteration = "ka" },
                new SyllabaryCharacter { Hiragana = "が", Katakana = "ガ", Transliteration = "ga" },
                new SyllabaryCharacter { Hiragana = "き", Katakana = "キ", Transliteration = "ki" },
                new SyllabaryCharacter { Hiragana = "ぎ", Katakana = "ギ", Transliteration = "gi" },
                new SyllabaryCharacter { Hiragana = "く", Katakana = "ク", Transliteration = "ku" },
                new SyllabaryCharacter { Hiragana = "ぐ", Katakana = "グ", Transliteration = "gu" },
                new SyllabaryCharacter { Hiragana = "け", Katakana = "ケ", Transliteration = "ke" },
                new SyllabaryCharacter { Hiragana = "げ", Katakana = "ゲ", Transliteration = "ge" },
                new SyllabaryCharacter { Hiragana = "こ", Katakana = "コ", Transliteration = "ko" },
                new SyllabaryCharacter { Hiragana = "ご", Katakana = "ゴ", Transliteration = "go" },
                new SyllabaryCharacter { Hiragana = "さ", Katakana = "サ", Transliteration = "sa" },
                new SyllabaryCharacter { Hiragana = "ざ", Katakana = "ザ", Transliteration = "za" },
                new SyllabaryCharacter { Hiragana = "し", Katakana = "シ", Transliteration = "shi" },
                new SyllabaryCharacter { Hiragana = "じ", Katakana = "ジ", Transliteration = "ji" },
                new SyllabaryCharacter { Hiragana = "す", Katakana = "ス", Transliteration = "su" },
                new SyllabaryCharacter { Hiragana = "ず", Katakana = "ズ", Transliteration = "zu" },
                new SyllabaryCharacter { Hiragana = "せ", Katakana = "セ", Transliteration = "se" },

                new SyllabaryCharacter { Hiragana = "ぜ", Katakana = "ゼ", Transliteration = "ze" },
                new SyllabaryCharacter { Hiragana = "そ", Katakana = "ソ", Transliteration = "so" },
                new SyllabaryCharacter { Hiragana = "ぞ", Katakana = "ゾ", Transliteration = "zo" },
                new SyllabaryCharacter { Hiragana = "た", Katakana = "タ", Transliteration = "ta" },
                new SyllabaryCharacter { Hiragana = "だ", Katakana = "ダ", Transliteration = "da" },
                new SyllabaryCharacter { Hiragana = "ち", Katakana = "チ", Transliteration = "chi" },
                new SyllabaryCharacter { Hiragana = "ぢ", Katakana = "ヂ", Transliteration = "ji" },
                new SyllabaryCharacter { Hiragana = "つ", Katakana = "ツ", Transliteration = "tsu" },
                new SyllabaryCharacter { Hiragana = "づ", Katakana = "ヅ", Transliteration = "zu" },
                new SyllabaryCharacter { Hiragana = "て", Katakana = "テ", Transliteration = "te" },
                new SyllabaryCharacter { Hiragana = "で", Katakana = "デ", Transliteration = "de" },
                new SyllabaryCharacter { Hiragana = "と", Katakana = "ト", Transliteration = "to" },
                new SyllabaryCharacter { Hiragana = "ど", Katakana = "ド", Transliteration = "do" },
                new SyllabaryCharacter { Hiragana = "な", Katakana = "ナ", Transliteration = "na" },
                new SyllabaryCharacter { Hiragana = "に", Katakana = "ニ", Transliteration = "ni" },
                new SyllabaryCharacter { Hiragana = "ぬ", Katakana = "ヌ", Transliteration = "nu" },
                new SyllabaryCharacter { Hiragana = "ね", Katakana = "ネ", Transliteration = "ne" },
                new SyllabaryCharacter { Hiragana = "の", Katakana = "ノ", Transliteration = "no" },
                new SyllabaryCharacter { Hiragana = "は", Katakana = "ハ", Transliteration = "ha" },
                new SyllabaryCharacter { Hiragana = "ば", Katakana = "バ", Transliteration = "ba" },
                new SyllabaryCharacter { Hiragana = "ぱ", Katakana = "パ", Transliteration = "pa" },
                new SyllabaryCharacter { Hiragana = "ひ", Katakana = "ヒ", Transliteration = "hi" },
                new SyllabaryCharacter { Hiragana = "び", Katakana = "ビ", Transliteration = "bi" },
                new SyllabaryCharacter { Hiragana = "ぴ", Katakana = "ピ", Transliteration = "pi" },
                new SyllabaryCharacter { Hiragana = "ふ", Katakana = "フ", Transliteration = "fu" },
                new SyllabaryCharacter { Hiragana = "ぶ", Katakana = "ブ", Transliteration = "bu" },
                new SyllabaryCharacter { Hiragana = "ぷ", Katakana = "プ", Transliteration = "pu" },
                new SyllabaryCharacter { Hiragana = "へ", Katakana = "ヘ", Transliteration = "he" },
                new SyllabaryCharacter { Hiragana = "べ", Katakana = "ベ", Transliteration = "be" },
                new SyllabaryCharacter { Hiragana = "ぺ", Katakana = "ペ", Transliteration = "pe" },
                new SyllabaryCharacter { Hiragana = "ほ", Katakana = "ホ", Transliteration = "ho" },
                new SyllabaryCharacter { Hiragana = "ぼ", Katakana = "ボ", Transliteration = "bo" },
                new SyllabaryCharacter { Hiragana = "ぽ", Katakana = "ポ", Transliteration = "po" },
                new SyllabaryCharacter { Hiragana = "ま", Katakana = "マ", Transliteration = "ma" },
                new SyllabaryCharacter { Hiragana = "み", Katakana = "ミ", Transliteration = "mi" },
                new SyllabaryCharacter { Hiragana = "む", Katakana = "ム", Transliteration = "mu" },
                new SyllabaryCharacter { Hiragana = "め", Katakana = "メ", Transliteration = "me" },
                new SyllabaryCharacter { Hiragana = "も", Katakana = "モ", Transliteration = "mo" },
                new SyllabaryCharacter { Hiragana = "や", Katakana = "ヤ", Transliteration = "ya" },
                new SyllabaryCharacter { Hiragana = "ゆ", Katakana = "ユ", Transliteration = "yu" },
                new SyllabaryCharacter { Hiragana = "よ", Katakana = "ヨ", Transliteration = "yo" }
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
            return GetSyllabaryCharacters()
                .Where(x => x.Katakana == what || x.Hiragana == what || x.Transliteration == what).FirstOrDefault();
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

        private static string GetRandomKatakana()
        {
            Random rnd = new Random();
            return katakana[rnd.Next(katakana.Count())];
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