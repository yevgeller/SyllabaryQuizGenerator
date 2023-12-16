namespace SyllabaryQuizGenerator.Tests
{
    [TestClass]
    public class SyllabaryShould
    {
        char[] katakanaSyllables, hiraganaSyllables;
        List<string> translit;

        [TestInitialize]
        public void Initialize()
        {
            katakanaSyllables = "アイウエオカガキギクグケゲコゴサザシジスズセゼソゾタダチヂッツヅテデトドナニヌネノハバパヒビピフブプヘベペホボポマミムメモャヤュユョヨラリルレロヮワヰヱヲンヴ".ToCharArray();
            hiraganaSyllables = "あいうえおかがきぎくぐけげこごさざしじすずせぜそぞただちぢっつづてでとどなにぬねのはばぱひびぴふぶぷへべぺほぼぽまみむめもゃやゅゆょよらりるれろゎわゐゑをんゔ".ToCharArray();
            translit = "a i u e o ka ga ki gi ku gu ke ge ko go sa za shi ji su zu se ze so zo ta da chi ji tsu zu te de to do na ni nu ne no ha ba pa hi bi pi fu bu pu he be pe ho bo po ma mi mu me mo ya yu yo".Split(' ').ToList<string>();
        }

        [TestMethod]
        public void Check_IsKatakana()
        {
            foreach (char k in katakanaSyllables)
            {
                Assert.IsTrue(Syllabary.Syllabary.IsKatakana(k.ToString()));
            }

        }

        [TestMethod]
        public void All_HaveOrdinalNumbers()
        {
            Assert.IsFalse(Syllabary.Syllabary.GetSyllabaryCharacters().Any(x=>x.OrdinalNumber < 1));
        }

        [TestMethod]
        public void Check_IsHiragana()
        {
            foreach (char h in hiraganaSyllables)
            {
                Assert.IsTrue(Syllabary.Syllabary.IsHiragana(h.ToString()));
            }
        }

        [TestMethod]
        public void Check_IsTransliteration()
        {
            foreach (var s in translit)
            {
                Assert.IsTrue(Syllabary.Syllabary.IsTransliteration(s));
            }
        }

        [TestMethod]
        public void Check_NotIsHiragana()
        {
            foreach (char h in hiraganaSyllables)
            {
                Assert.IsFalse(Syllabary.Syllabary.IsKatakana(h.ToString()));
                Assert.IsFalse(Syllabary.Syllabary.IsTransliteration(h.ToString()));
            }
        }

        [TestMethod]
        public void Check_NotIsKatakana()
        {
            foreach (char k in katakanaSyllables)
            {
                Assert.IsFalse(Syllabary.Syllabary.IsHiragana(k.ToString()));
                Assert.IsFalse(Syllabary.Syllabary.IsTransliteration(k.ToString()));
            }
        }

        [TestMethod]
        public void GenerateKatakanaAnswers_NotRepeating()
        {
            foreach (char k in katakanaSyllables)
            {
                var list = Syllabary.Syllabary.GenerateKatakanaAnswers(k.ToString(), 6);
                Dictionary<string, int> dic = new Dictionary<string, int>();

                foreach (var i in list)
                {
                    Assert.IsFalse(dic.ContainsKey(i.ToString()), $"Answer {i} found among other answers");
                    dic.Add(i, 1);
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
                var randomKatakana = Syllabary.Syllabary.GetRandomKatakana();
                if (!dic.ContainsKey(randomKatakana))
                    dic.Add(randomKatakana, 1);
                else
                    dic[randomKatakana]++;
            }

            Assert.AreEqual(katakanaSyllables.Length, dic.Keys.Count, $"Not enough randomness in random Katakana over {n} attempts.");
        }
    }
}
