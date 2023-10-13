using System;
using System.Collections.Generic;
using System.Linq;
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
        static string hiragana = "あいうえおかがきぎくぐけげこごさざしじすずせぜそぞただちぢっつづてでとどなにぬねのはばぱひびぴふぶぷへべぺほぼぽまみむめもゃやゅゆょよらりるれろゎわゐゑをんゔ";
        static string katakana = "アイウエオカガキギクグケゲコゴサザシジスズセゼソゾタダチヂッツヅテデトドナニヌネノハバパヒビピフブプヘベペホボポマミムメモャヤュユョヨラリルレロヮワヰヱヲンヴ";

        public static List<SyllabaryCharacter> GetSyllabaryCharacters()
        {
            List<SyllabaryCharacter> result = new List<SyllabaryCharacter>();
            result.Add(new SyllabaryCharacter { Hiragana = "あ", Katakana = "ア", Transliteration = "a" });
            result.Add(new SyllabaryCharacter { Hiragana = "い", Katakana = "イ", Transliteration = "i" });
            result.Add(new SyllabaryCharacter { Hiragana = "う", Katakana = "ウ", Transliteration = "u" });
            result.Add(new SyllabaryCharacter { Hiragana = "え", Katakana = "エ", Transliteration = "e" });
            result.Add(new SyllabaryCharacter { Hiragana = "お", Katakana = "オ", Transliteration = "o" });
            result.Add(new SyllabaryCharacter { Hiragana = "か", Katakana = "カ", Transliteration = "ka" });
            result.Add(new SyllabaryCharacter { Hiragana = "が", Katakana = "ガ", Transliteration = "ga" });
            result.Add(new SyllabaryCharacter { Hiragana = "き", Katakana = "キ", Transliteration = "ki" });
            result.Add(new SyllabaryCharacter { Hiragana = "ぎ", Katakana = "ギ", Transliteration = "gi" });
            result.Add(new SyllabaryCharacter { Hiragana = "く", Katakana = "ク", Transliteration = "ku" });
            result.Add(new SyllabaryCharacter { Hiragana = "ぐ", Katakana = "グ", Transliteration = "gu" });
            result.Add(new SyllabaryCharacter { Hiragana = "け", Katakana = "ケ", Transliteration = "ke" });
            result.Add(new SyllabaryCharacter { Hiragana = "げ", Katakana = "ゲ", Transliteration = "ge" });
            result.Add(new SyllabaryCharacter { Hiragana = "こ", Katakana = "コ", Transliteration = "ko" });
            result.Add(new SyllabaryCharacter { Hiragana = "ご", Katakana = "ゴ", Transliteration = "go" });
            result.Add(new SyllabaryCharacter { Hiragana = "さ", Katakana = "サ", Transliteration = "sa" });
            result.Add(new SyllabaryCharacter { Hiragana = "ざ", Katakana = "ザ", Transliteration = "za" });
            result.Add(new SyllabaryCharacter { Hiragana = "し", Katakana = "シ", Transliteration = "shi" });
            result.Add(new SyllabaryCharacter { Hiragana = "じ", Katakana = "ジ", Transliteration = "ji" });
            result.Add(new SyllabaryCharacter { Hiragana = "す", Katakana = "ス", Transliteration = "su" });
            result.Add(new SyllabaryCharacter { Hiragana = "ず", Katakana = "ズ", Transliteration = "zu" });
            result.Add(new SyllabaryCharacter { Hiragana = "せ", Katakana = "セ", Transliteration = "se" });

            result.Add(new SyllabaryCharacter { Hiragana = "ぜ", Katakana = "ゼ", Transliteration = "ze" });
            result.Add(new SyllabaryCharacter { Hiragana = "そ", Katakana = "ソ", Transliteration = "so" });
            result.Add(new SyllabaryCharacter { Hiragana = "ぞ", Katakana = "ゾ", Transliteration = "zo" });
            result.Add(new SyllabaryCharacter { Hiragana = "た", Katakana = "タ", Transliteration = "ta" });
            result.Add(new SyllabaryCharacter { Hiragana = "だ", Katakana = "ダ", Transliteration = "da" });
            result.Add(new SyllabaryCharacter { Hiragana = "ち", Katakana = "チ", Transliteration = "chi" });
            result.Add(new SyllabaryCharacter { Hiragana = "ぢ", Katakana = "ヂ", Transliteration = "ji" });
            result.Add(new SyllabaryCharacter { Hiragana = "つ", Katakana = "ツ", Transliteration = "tsu" });
            result.Add(new SyllabaryCharacter { Hiragana = "づ", Katakana = "ヅ", Transliteration = "zu" });
            result.Add(new SyllabaryCharacter { Hiragana = "て", Katakana = "テ", Transliteration = "te" });
            result.Add(new SyllabaryCharacter { Hiragana = "で", Katakana = "デ", Transliteration = "de" });
            result.Add(new SyllabaryCharacter { Hiragana = "と", Katakana = "ト", Transliteration = "to" });
            result.Add(new SyllabaryCharacter { Hiragana = "ど", Katakana = "ド", Transliteration = "do" });
            result.Add(new SyllabaryCharacter { Hiragana = "な", Katakana = "ナ", Transliteration = "na" });
            result.Add(new SyllabaryCharacter { Hiragana = "に", Katakana = "ニ", Transliteration = "ni" });
            result.Add(new SyllabaryCharacter { Hiragana = "ぬ", Katakana = "ヌ", Transliteration = "nu" });
            result.Add(new SyllabaryCharacter { Hiragana = "ね", Katakana = "ネ", Transliteration = "ne" });
            result.Add(new SyllabaryCharacter { Hiragana = "の", Katakana = "ノ", Transliteration = "no" });
            result.Add(new SyllabaryCharacter { Hiragana = "は", Katakana = "ハ", Transliteration = "ha" });
            result.Add(new SyllabaryCharacter { Hiragana = "ば", Katakana = "バ", Transliteration = "ba" });
            result.Add(new SyllabaryCharacter { Hiragana = "ぱ", Katakana = "パ", Transliteration = "pa" });
            result.Add(new SyllabaryCharacter { Hiragana = "ひ", Katakana = "ヒ", Transliteration = "hi" });
            result.Add(new SyllabaryCharacter { Hiragana = "び", Katakana = "ビ", Transliteration = "bi" });
            result.Add(new SyllabaryCharacter { Hiragana = "ぴ", Katakana = "ピ", Transliteration = "pi" });
            result.Add(new SyllabaryCharacter { Hiragana = "ふ", Katakana = "フ", Transliteration = "fu" });
            result.Add(new SyllabaryCharacter { Hiragana = "ぶ", Katakana = "ブ", Transliteration = "bu" });
            result.Add(new SyllabaryCharacter { Hiragana = "ぷ", Katakana = "プ", Transliteration = "pu" });
            result.Add(new SyllabaryCharacter { Hiragana = "へ", Katakana = "ヘ", Transliteration = "he" });
            result.Add(new SyllabaryCharacter { Hiragana = "べ", Katakana = "ベ", Transliteration = "be" });
            result.Add(new SyllabaryCharacter { Hiragana = "ぺ", Katakana = "ペ", Transliteration = "pe" });
            result.Add(new SyllabaryCharacter { Hiragana = "ほ", Katakana = "ホ", Transliteration = "ho" });
            result.Add(new SyllabaryCharacter { Hiragana = "ぼ", Katakana = "ボ", Transliteration = "bo" });
            result.Add(new SyllabaryCharacter { Hiragana = "ぽ", Katakana = "ポ", Transliteration = "po" });
            result.Add(new SyllabaryCharacter { Hiragana = "ま", Katakana = "マ", Transliteration = "ma" });
            result.Add(new SyllabaryCharacter { Hiragana = "み", Katakana = "ミ", Transliteration = "mi" });
            result.Add(new SyllabaryCharacter { Hiragana = "む", Katakana = "ム", Transliteration = "mu" });
            result.Add(new SyllabaryCharacter { Hiragana = "め", Katakana = "メ", Transliteration = "me" });
            result.Add(new SyllabaryCharacter { Hiragana = "も", Katakana = "モ", Transliteration = "mo" });
            result.Add(new SyllabaryCharacter { Hiragana = "や", Katakana = "ヤ", Transliteration = "ya" });
            result.Add(new SyllabaryCharacter { Hiragana = "ゆ", Katakana = "ユ", Transliteration = "yu" });
            result.Add(new SyllabaryCharacter { Hiragana = "よ", Katakana = "ヨ", Transliteration = "yo" });

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
            return hiragana.IndexOf(syllable) >= 0; //TODO: switch to numbers something 
        }

        public static bool IsKatakana(string syllable)
        {
            return katakana.IndexOf(syllable) >= 0;
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