using System.Linq;

namespace SyllabaryQuizGenerator.Tests
{
    [TestClass]
    public class SyllabaryShould
    {
        List<string> translit, katakanaSyllables, hiraganaSyllables;

        [TestInitialize]
        public void Initialize()
        {
            katakanaSyllables = "ア,イ,ウ,エ,オ,カ,ガ,キ,ギ,ク,グ,ケ,ゲ,コ,ゴ,サ,ザ,シ,ジ,ス,ズ,セ,ゼ,ソ,ゾ,タ,ダ,チ,ヂ,ッ,ツ,ヅ,テ,デ,ト,ド,ナ,ニ,ヌ,ネ,ノ,ハ,バ,パ,ヒ,ビ,ピ,フ,ブ,プ,ヘ,ベ,ペ,ホ,ボ,ポ,マ,ミ,ム,メ,モ,ャ,ヤ,ュ,ユ,ョ,ヨ,ラ,リ,ル,レ,ロ,ヮ,ワ,ヰ,ヱ,ヲ,ン,ヴ".Split(',').ToList<string>();
            hiraganaSyllables = "あ,い,う,え,お,か,が,き,ぎ,く,ぐ,け,げ,こ,ご,さ,ざ,し,じ,す,ず,せ,ぜ,そ,ぞ,た,だ,ち,ぢ,っ,つ,づ,て,で,と,ど,な,に,ぬ,ね,の,は,ば,ぱ,ひ,び,ぴ,ふ,ぶ,ぷ,へ,べ,ぺ,ほ,ぼ,ぽ,ま,み,む,め,も,ゃ,や,ゅ,ゆ,ょ,よ,ら,り,る,れ,ろ,ゎ,わ,ゐ,ゑ,を,ん,ゔ".Split(',').ToList<string>();
            translit = "a i u e o ka ga ki gi ku gu ke ge ko go sa za shi ji su zu se ze so zo ta da chi ji tsu zu te de to do na ni nu ne no ha ba pa hi bi pi fu bu pu he be pe ho bo po ma mi mu me mo ya yu yo".Split(' ').ToList<string>();
        }

        [TestMethod]
        public void Check_IsKatakana()
        {
            foreach (string k in katakanaSyllables)
            {
                Assert.IsTrue(Syllabary.IsKatakana(k.ToString()));
            }

        }

        [TestMethod]
        public void All_HaveOrdinalNumbers()
        {
            Assert.IsFalse(Syllabary.GetSyllabaryCharacters().Any(x=>x.OrdinalNumber < 1));
        }

        [TestMethod]
        public void Check_IsHiragana()
        {
            foreach (string h in hiraganaSyllables)
            {
                Assert.IsTrue(Syllabary.IsHiragana(h.ToString()));
            }
        }

        [TestMethod]
        public void Check_IsTransliteration()
        {
            foreach (var s in translit)
            {
                Assert.IsTrue(Syllabary.IsTransliteration(s));
            }
        }

        [TestMethod]
        public void Check_NotIsHiragana()
        {
            foreach (string h in hiraganaSyllables)
            {
                Assert.IsFalse(Syllabary.IsKatakana(h.ToString()));
                Assert.IsFalse(Syllabary.IsTransliteration(h.ToString()));
            }
        }

        [TestMethod]
        public void Check_NotIsKatakana()
        {
            foreach (string k in katakanaSyllables)
            {
                Assert.IsFalse(Syllabary.IsHiragana(k.ToString()));
                Assert.IsFalse(Syllabary.IsTransliteration(k.ToString()));
            }
        }

        [TestMethod]
        public void GenerateKatakanaAnswers_NotRepeating()
        {
            foreach (string k in katakanaSyllables)
            {
                var list = Syllabary.GenerateAnswers(Syllabary.GetRandomKatakana, k, 6);
                Dictionary<string, int> dic = new Dictionary<string, int>();

                foreach (var i in list)
                {
                    Assert.IsFalse(dic.ContainsKey(i.ToString()), $"Answer {i} found among other answers");
                    dic.Add(i, 1);
                }

            }
        }

        [TestMethod]
        public void GenerateKatakanaAnswers_AllAnswersAreKatakana()
        {
            foreach (string k in katakanaSyllables)
            {
                var list = Syllabary.GenerateKatakanaAnswers(k.ToString(), 6);
                foreach (var i in list)
                {
                    Assert.IsTrue(katakanaSyllables.Contains(i), $"{i} is not a Katakana character");
                }
            }
        }

        [TestMethod]
        public void GenerateTransliterationAnswers_NotRepeating()
        {
            foreach (string t in translit)
            {
                var list = Syllabary.GenerateAnswers(Syllabary.GetRandomTransliteration, t, 6);
                Dictionary<string, int> dic = new Dictionary<string, int>();

                foreach (var i in list)
                {
                    Assert.IsFalse(dic.ContainsKey(i.ToString()), $"Answer {i} found among other answers");
                    dic.Add(i, 1);
                }

            }
        }

        [TestMethod]
        public void GenerateTransliterationAnswers_AllAnswersAreTransliteration()
        {
            foreach (string t in translit)
            {
                var list = Syllabary.GenerateAnswers(Syllabary.GetRandomTransliteration, t, 6);
                foreach(var i in list)
                {
                    Assert.IsTrue(translit.Contains(i), $"{i} is not a transliteration character");
                }
            }
        }

        [TestMethod]
        public void GetRandomKatakana_AnswersSomewhatRandom()
        {
            var n = 10000;
            Dictionary<string, int> dic  = new Dictionary<string, int>();
            for(int i = 0; i < n; i++)
            {
                var randomKatakana = Syllabary.GetRandomKatakana();
                if (!dic.ContainsKey(randomKatakana))
                    dic.Add(randomKatakana, 1);
                else
                    dic[randomKatakana]++;
            }

            Assert.AreEqual(katakanaSyllables.Count, dic.Keys.Count, $"Not enough randomness in random Katakana over {n} attempts.");
        }
    }
}
